using ClientBlog.Models;

namespace ClientBlog.Services
{
    public static class PortfolioDataService
    {
        private static readonly List<ProjectItem> _devProjects = new()
        {
            new ProjectItem
            {
                Name = "ZeroPaper",
                Slug = "zeropaper",
                Rank = "Main product",
                Summary = "Modular platform for small businesses - link sales, QR Code, WhatsApp, orders and cash flow",
                Description = "ZeroPaper is a modular operations platform for small businesses. It helps teams sell through links, QR Code and WhatsApp, organize orders, customers, payments and daily cash flow in one clear panel.",
                ImagePath = "~/img/ProjectsIMGs/zeropaper-logo-512.png",
                ImageAlt = "ZeroPaper logo",
                Tags = new() { "Modular platform", "QR Code", "WhatsApp", "Orders", "Cash flow", "ASP.NET Core" },
                GitHubUrl = "https://github.com/AlexssanderLX/ZeroPaper",
                ProjectUrl = "https://zeropaperflow.com.br",
                IsFeatured = true,
                ContentConfirmed = true,
                Status = "active",
                Order = 1
            },
            new ProjectItem
            {
                Name = "LedgerFlow",
                Slug = "ledgerflow",
                Rank = "Business workflow",
                Summary = "Accounting workflow - documents, fiscal routines and operational visibility",
                Description = "LedgerFlow organizes client records, document modules, DAS and DEFIS drafts, and operational visibility for an accounting office. It turns administrative routines into a cleaner and more traceable workflow.",
                ImagePath = "~/img/ProjectsIMGs/LedgerFlow-logo.png",
                ImageAlt = "LedgerFlow logo",
                Tags = new() { "Accounting workflow", "Documents", "Fiscal routines", "ASP.NET Core" },
                GitHubUrl = "https://github.com/AlexssanderLX/LedgerFlow",
                IsFeatured = false,
                ContentConfirmed = true,
                Status = "active",
                Order = 2
            },
            new ProjectItem
            {
                Name = "StoreFlow",
                Slug = "storeflow",
                Rank = "Internal operations",
                Summary = "Store routines - missing-item records, stock signals and daily workflow",
                Description = "StoreFlow records missing products, organizes internal routines and makes repetitive store processes easier to track. It focuses on practical operational control rather than customer-facing features.",
                ImagePath = "~/img/ProjectsIMGs/StoreFlow-logo.svg",
                ImageAlt = "StoreFlow logo",
                Tags = new() { "Internal operations", "Missing records", "Store workflow", "ASP.NET Core" },
                GitHubUrl = "https://github.com/AlexssanderLX/StoreFlow",
                IsFeatured = false,
                ContentConfirmed = true,
                Status = "active",
                Order = 3
            },
            new ProjectItem
            {
                Name = "YourRhythm Studio",
                Slug = "your-rhythm-studio",
                Rank = "Music education product",
                Summary = "Platform for music teachers and schools - students, lessons, repertoire, missions and XP",
                Description = "YourRhythm Studio helps teachers and music schools organize students, lessons, repertoire and weekly missions. The product keeps progress visible through XP, streaks, feedback and a virtual piano experience.",
                ImagePath = "~/img/ProjectsIMGs/YourRhythmStudio-Logo.png",
                ImageAlt = "YourRhythm Studio logo",
                Tags = new() { "Music education", "Students", "Lessons", "Missions", "XP" },
                ProjectUrl = "https://yourrhythmstudio.com.br",
                IsFeatured = false,
                ContentConfirmed = true,
                Status = "active",
                Order = 4
            },
            new ProjectItem
            {
                Name = "Job Radar",
                Slug = "job-radar",
                Rank = "In development",
                Summary = "Job monitoring - organization and automation",
                Description = "",
                ImagePath = null,
                ImageAlt = null,
                Tags = new() { "Automation", "Jobs", "In development" },
                GitHubUrl = null,
                IsFeatured = false,
                ContentConfirmed = false,
                Status = "coming-soon",
                Order = 5
            }
        };

        private static readonly List<CtfCase> _ctfCases = new()
        {
            new CtfCase
            {
                Name = "Injectics",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/injectics",
                ImagePath = "~/img/ProjectsIMGs/Injectics.png",
                ImageAlt = "Injectics CTF",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Web application with multiple input points susceptible to data injection.",
                Vector = "Mapped application behavior, identified vulnerable parameters and chained injection techniques to compromise the session.",
                Learning = "Injection is contextual: filters, parameters and trust boundaries must be reviewed together before release.",
                Mitigation = "Parameterized queries, context-aware sanitization, strict input validation and a properly configured WAF.",
                Tags = new() { "Injection", "Web", "Auth bypass" },
                IsFeatured = true,
                Order = 1
            },
            new CtfCase
            {
                Name = "Athena",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/4th3n4",
                ImagePath = "~/img/ProjectsIMGs/AthenaTHM.png",
                ImageAlt = "Athena TryHackMe room",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Themed lab that rewards disciplined enumeration before selecting the exploitation path.",
                Vector = "Service discovery, web analysis and Linux privilege escalation practice in a controlled environment.",
                Learning = "A clean methodology beats guessing: map the surface, validate assumptions and document the chain.",
                Mitigation = "Least privilege, exposed-service review, credential hygiene and consistent patch management.",
                Tags = new() { "Enumeration", "Linux", "PrivEsc" },
                IsFeatured = false,
                Order = 2
            },
            new CtfCase
            {
                Name = "WhyHackMe",
                Slug = "whyhackme",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/whyhackme",
                ImagePath = "~/img/ProjectsIMGs/WhyHackMe.webp",
                ImageAlt = "WhyHackMe TryHackMe room",
                ReportPdfPath = "~/reports/ctf/whyhackme-report.pdf",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Web-focused room that mixes compromise, analysis and careful interpretation of application behavior.",
                Vector = "Enumerated exposed services and web clues, validated assumptions and followed the chain toward controlled compromise.",
                Learning = "Good exploitation depends on analysis first: understand the application, reduce noise and only then execute the path.",
                Mitigation = "Harden exposed services, reduce information leakage, validate server-side behavior and keep authentication controls consistent.",
                Tags = new() { "Web", "Analysis", "Enumeration" },
                IsFeatured = false,
                Order = 3
            },
            new CtfCase
            {
                Name = "Silent Monitor",
                Slug = "silent-monitor",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/silent-monitor",
                ImagePath = "~/img/ProjectsIMGs/SilentMonitor.webp",
                ImageAlt = "Silent Monitor TryHackMe room",
                ReportPdfPath = "~/reports/ctf/silent-monitor-report.pdf",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Monitoring-themed lab focused on quiet enumeration, evidence review and controlled compromise.",
                Vector = "Followed observable signals, correlated exposed services and validated the exploitation path without relying on noisy assumptions.",
                Learning = "Security analysis is strongest when evidence drives each step: observe, confirm and only then exploit within scope.",
                Mitigation = "Reduce exposed telemetry, harden services, review access controls and monitor suspicious behavior with actionable logging.",
                Tags = new() { "Monitoring", "Enumeration", "Analysis" },
                IsFeatured = false,
                Order = 4
            },
            new CtfCase
            {
                Name = "Hammer",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/hammer",
                ImagePath = "~/img/ProjectsIMGs/Hammer.png",
                ImageAlt = "Hammer CTF",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Web application with an authentication flow protected by insufficient controls.",
                Vector = "Analyzed the full auth flow, identified session control weakness and escalated to remote code execution.",
                Learning = "Multi-step authentication fails when only one layer is verified. Understanding the complete flow reveals blind spots.",
                Mitigation = "State verification at each step, token expiration, rate limiting and authentication event logging.",
                Tags = new() { "Auth bypass", "RCE", "Web" },
                IsFeatured = false,
                Order = 5
            },
            new CtfCase
            {
                Name = "Recruit",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/recruitwebchallenge",
                ImagePath = "~/img/ProjectsIMGs/Recruit.png",
                ImageAlt = "Recruit CTF",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Web challenge with multiple attack surfaces requiring structured enumeration.",
                Vector = "Systematic enumeration of directories, parameters and endpoints before selecting the correct exploitation vector.",
                Learning = "Application behavior patterns reveal the real attack surface before any exploit.",
                Mitigation = "Remove unnecessary files, handle errors without leaking internals and enforce consistent access control.",
                Tags = new() { "Enumeration", "Web", "Exploitation" },
                IsFeatured = false,
                Order = 6
            },
            new CtfCase
            {
                Name = "Pickle Rick",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/r/room/picklerick",
                ImagePath = "~/img/ProjectsIMGs/PickleRick.jpeg",
                ImageAlt = "Pickle Rick CTF",
                Difficulty = "Easy",
                DifficultyClass = "easy",
                Scenario = "Classic lab combining web enumeration with Linux privilege escalation.",
                Vector = "Chained small findings: information disclosure in the app, command execution and server-side privilege escalation.",
                Learning = "Small exposures chain together. An HTML comment, a forgotten file and loose permissions can be enough.",
                Mitigation = "Remove debug information, apply least privilege and review web server configuration.",
                Tags = new() { "Linux", "PrivEsc", "Web" },
                IsFeatured = false,
                Order = 7
            },
            new CtfCase
            {
                Name = "Decryptify",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/decryptify",
                ImagePath = "~/img/ProjectsIMGs/Decryptify.png",
                ImageAlt = "Decryptify CTF",
                Difficulty = "Medium",
                DifficultyClass = "medium",
                Scenario = "Lab with a cryptographic challenge that escalates to remote code execution.",
                Vector = "Analyzed cryptographic tokens, recovered keys and connected the technical interpretation to the RCE vector.",
                Learning = "Poorly implemented cryptography is a false sense of security.",
                Mitigation = "Modern algorithms, secure key management, context separation and server-side validation.",
                Tags = new() { "Cryptography", "RCE", "Analysis" },
                IsFeatured = false,
                Order = 8
            },
            new CtfCase
            {
                Name = "Webmin Exploitation - Source",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/source",
                ImagePath = "~/img/ProjectsIMGs/Source.png",
                ImageAlt = "Source CTF",
                Difficulty = "Easy",
                DifficultyClass = "easy",
                Scenario = "Server running a vulnerable version of Webmin exposed to the network.",
                Vector = "Version identification, CVE mapping and controlled exploitation of Webmin in a lab environment.",
                Learning = "Outdated software with an exposed admin panel is a direct target.",
                Mitigation = "Continuous maintenance, security updates, admin panel access restriction and periodic scanning.",
                Tags = new() { "CVE", "Enumeration", "RCE" },
                IsFeatured = false,
                Order = 9
            },
            new CtfCase
            {
                Name = "Bricks Heist",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/tryhack3mbricksheist",
                ImagePath = "~/img/ProjectsIMGs/TheBricks.png",
                ImageAlt = "Bricks Heist CTF",
                Difficulty = "Easy",
                DifficultyClass = "easy",
                Scenario = "Lab based on a recent CVE focused on RCE and bypassing system restrictions.",
                Vector = "Exploited a recent vulnerability, bypassed system restrictions and escalated privileges in a controlled environment.",
                Learning = "Recent CVEs have short exploitation windows. Understanding the root cause matters more than the exploit itself.",
                Mitigation = "CVE monitoring, structured patch management and OS hardening.",
                Tags = new() { "Recent CVE", "PrivEsc", "RCE" },
                IsFeatured = false,
                Order = 10
            }
        };

        private static readonly List<Composition> _compositions = new()
        {
            new Composition
            {
                Name = "Sunshine Etude in G minor",
                Type = "Piano etude",
                Year = "2025",
                Description = "Original piano study built around harmonic contrast, rhythmic tension and emotional development.",
                Tags = new() { "Piano", "Original composition", "2025", "Emotional arc" },
                BandLabUrl = "https://www.bandlab.com/track/b798db6d-4ecc-ef11-88cd-6045bd345b20?revId=b698db6d-4ecc-ef11-88cd-6045bd345b20",
                IsFeatured = true,
                Order = 1
            },
            new Composition
            {
                Name = "Maybe It Is",
                Type = "Expressive record",
                Year = "2025",
                Description = "A piano piece shaped as personal expression, turning feeling and observation into musical language.",
                Tags = new() { "Piano", "Emotional expression", "2025", "Interpretation" },
                BandLabUrl = "https://www.bandlab.com/track/f1a0f7b2-57ee-f011-8d4d-002248444940?revId=f0a0f7b2-57ee-f011-8d4d-002248444940",
                IsFeatured = false,
                Order = 2
            }
        };

        public static IReadOnlyList<ProjectItem> GetDevelopmentProjects() => _devProjects.AsReadOnly();

        public static IReadOnlyList<CtfCase> GetSecurityCases() => _ctfCases.AsReadOnly();

        public static CtfCase? GetSecurityCaseBySlug(string slug)
        {
            return _ctfCases.FirstOrDefault(ctf =>
                !string.IsNullOrWhiteSpace(ctf.Slug) &&
                string.Equals(ctf.Slug, slug, StringComparison.OrdinalIgnoreCase));
        }

        public static IReadOnlyList<Composition> GetCompositions() => _compositions.AsReadOnly();
    }
}
