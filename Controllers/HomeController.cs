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
            ViewData["Title"] = "Desenvolvimento";
            ViewData["Description"] = "Plataformas web, SaaS, automações e infraestrutura aplicada. Do frontend ao servidor — desenvolvimento completo com segurança integrada.";
            var projects = PortfolioDataService.GetDevelopmentProjects();
            return View(projects);
        }

        [OutputCache(Duration = 600)]
        public IActionResult Security()
        {
            ViewData["Title"] = "Segurança";
            ViewData["Description"] = "Segurança de aplicações, pentest, CTFs e DevSecOps. Análise, exploração controlada e mitigação de vulnerabilidades reais.";
            var cases = PortfolioDataService.GetSecurityCases();
            return View(cases);
        }

        [OutputCache(Duration = 600)]
        public IActionResult Music()
        {
            ViewData["Title"] = "Música";
            ViewData["Description"] = "Piano, composição, jazz e aulas. Técnica, percepção e criatividade — do repertório clássico à composição original.";
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
