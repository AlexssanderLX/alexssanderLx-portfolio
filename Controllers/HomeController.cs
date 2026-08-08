using System.Diagnostics;
using ClientBlog.Models;
using ClientBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ClientBlog.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 600)]
        public IActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 600)]
        public IActionResult Projects()
        {
            return View();
        }

        [OutputCache(Duration = 600)]
        public IActionResult Development()
        {
            ViewData["Title"] = "Development";
            ViewData["Description"] = "Web products, SaaS platforms, automation and applied infrastructure. From interface to server, development with security built in.";
            var projects = PortfolioDataService.GetDevelopmentProjects();
            return View(projects);
        }

        [OutputCache(Duration = 600)]
        public IActionResult Security()
        {
            ViewData["Title"] = "Security";
            ViewData["Description"] = "Application security, pentest, CTFs and DevSecOps. Analysis, controlled exploitation and mitigation of real vulnerabilities.";
            var cases = PortfolioDataService.GetSecurityCases();
            return View(cases);
        }

        [OutputCache(Duration = 600)]
        public IActionResult CtfReport(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return RedirectToAction(nameof(Security));
            }

            var ctfCase = PortfolioDataService.GetSecurityCaseBySlug(slug);

            if (ctfCase == null || string.IsNullOrWhiteSpace(ctfCase.ReportPdfPath))
            {
                return NotFound();
            }

            ViewData["Title"] = $"{ctfCase.Name} Report";
            ViewData["Description"] = $"{ctfCase.Name} CTF report and practical pentest notes by Alexssander LX.";

            return View(ctfCase);
        }

        [OutputCache(Duration = 600)]
        public IActionResult Music()
        {
            ViewData["Title"] = "Music";
            ViewData["Description"] = "Piano, composition, jazz and lessons. Technique, ear training and creativity, from classical repertoire to original composition.";
            var compositions = PortfolioDataService.GetCompositions();
            return View(compositions);
        }

        [OutputCache(Duration = 600)]
        public IActionResult Contact()
        {
            return View();
        }

        [OutputCache(Duration = 600)]
        public IActionResult About()
        {
            return View();
        }

        [OutputCache(Duration = 600)]
        public IActionResult Rights()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [OutputCache(NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
