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
                Rank = "Produto principal",
                Summary = "SaaS para restaurantes · Pedidos QR · Fluxo de cozinha · Operações",
                Description = "Sistema operacional para restaurantes que conecta cardápio, mesas, pedidos por QR code, fluxo de cozinha, impressão e rotinas internas em uma única plataforma. Combina pensamento de produto, estrutura de backend, workflow multi-usuário e demandas operacionais reais.",
                ImagePath = "~/img/ProjectsIMGs/ZeroPaper-thumb.png",
                ImageAlt = "ZeroPaper preview",
                Tags = new() { "SaaS para restaurantes", "QR Code", "Fluxo de cozinha", "ASP.NET Core", "Operações" },
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
                Rank = "Workflow de negócio",
                Summary = "Workflow contábil · Documentos · Rotinas fiscais",
                Description = "Plataforma para organizar registros de clientes, módulos de documentos, rascunhos de DAS e DEFIS, e visibilidade operacional de um escritório contábil em uma estrutura mais limpa. Demonstra modelagem de processos, organização de informações e consistência em rotinas administrativas.",
                ImagePath = "~/img/ProjectsIMGs/LedgerFlow-logo.png",
                ImageAlt = "LedgerFlow logo",
                Tags = new() { "Workflow contábil", "Documentos", "Rotinas fiscais", "ASP.NET Core" },
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
                Rank = "Sistema operacional interno",
                Summary = "Operações internas · Registros de faltas · Fluxo de loja",
                Description = "Aplicação interna para registrar faltas de produtos, organizar rotinas operacionais diárias e reduzir desordem em processos repetitivos de loja. Transforma uma dor operacional em um fluxo mais limpo, centralizado e rastreável.",
                ImagePath = "~/img/ProjectsIMGs/StoreFlow-logo.svg",
                ImageAlt = "StoreFlow logo",
                Tags = new() { "Operações internas", "Registros de falta", "Fluxo de loja", "ASP.NET Core" },
                GitHubUrl = "https://github.com/AlexssanderLX/StoreFlow",
                IsFeatured = false,
                ContentConfirmed = true,
                Status = "active",
                Order = 3
            },
            new ProjectItem
            {
                Name = "Job Radar",
                Slug = "job-radar",
                Rank = "Em desenvolvimento",
                Summary = "Monitoramento de vagas · Organização · Automação",
                Description = "",
                ImagePath = null,
                ImageAlt = null,
                Tags = new() { "Automação", "Vagas", "Em desenvolvimento" },
                GitHubUrl = null,
                IsFeatured = false,
                ContentConfirmed = false,
                Status = "coming-soon",
                Order = 4
            },
            new ProjectItem
            {
                Name = "Your Rhythm Studio",
                Slug = "your-rhythm-studio",
                Rank = "Em desenvolvimento",
                Summary = "Plataforma para aulas de piano · Progresso · Repertório",
                Description = "",
                ImagePath = null,
                ImageAlt = null,
                Tags = new() { "Música", "Educação", "Em desenvolvimento" },
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
                Learning = "Deep understanding of how injection works beyond the basics: different contexts, insufficient filters and bypasses.",
                Mitigation = "Parameterized queries, context-aware sanitization, strict input validation and a properly configured WAF.",
                Tags = new() { "Injection", "Web", "Auth bypass" },
                IsFeatured = true,
                Order = 1
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
                Order = 2
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
                Learning = "Methodical recon avoids wasted time. Application behavior patterns reveal the real attack surface before any exploit.",
                Mitigation = "Remove unnecessary files, handle errors without leaking internals and enforce consistent access control.",
                Tags = new() { "Enumeration", "Web", "Exploitation" },
                IsFeatured = false,
                Order = 3
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
                Order = 4
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
                Learning = "Poorly implemented cryptography is a false sense of security. Weak keys, outdated algorithms and mixed contexts create real attack paths.",
                Mitigation = "Modern algorithms, secure key management, context separation and server-side validation.",
                Tags = new() { "Cryptography", "RCE", "Analysis" },
                IsFeatured = false,
                Order = 5
            },
            new CtfCase
            {
                Name = "Webmin Exploitation — Source",
                Platform = "TryHackMe",
                Url = "https://tryhackme.com/room/source",
                ImagePath = "~/img/ProjectsIMGs/Source.png",
                ImageAlt = "Source CTF",
                Difficulty = "Easy",
                DifficultyClass = "easy",
                Scenario = "Server running a vulnerable version of Webmin exposed to the network.",
                Vector = "Version identification, CVE mapping and controlled exploitation of Webmin in a lab environment.",
                Learning = "Outdated software with an exposed admin panel is a direct target. Version + CVE = immediate vector.",
                Mitigation = "Continuous maintenance, security updates, admin panel access restriction and periodic scanning.",
                Tags = new() { "CVE", "Enumeration", "RCE" },
                IsFeatured = false,
                Order = 6
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
                Learning = "Recent CVEs have short exploitation windows. Understanding the root cause of a vulnerability matters more than the exploit itself.",
                Mitigation = "CVE monitoring, structured patch management and OS hardening.",
                Tags = new() { "Recent CVE", "PrivEsc", "RCE" },
                IsFeatured = false,
                Order = 7
            }
        };

        private static readonly List<Composition> _compositions = new()
        {
            new Composition
            {
                Name = "Sunshine Etude in G minor",
                Type = "Estudo para piano",
                Year = "2025",
                Description = "Composição original construída em torno de contraste harmônico, tensão rítmica e desenvolvimento emocional em forma de narrativa.",
                Tags = new() { "Piano", "Composição original", "2025", "Arco emocional" },
                BandLabUrl = "https://www.bandlab.com/track/b798db6d-4ecc-ef11-88cd-6045bd345b20?revId=b698db6d-4ecc-ef11-88cd-6045bd345b20",
                IsFeatured = true,
                Order = 1
            },
            new Composition
            {
                Name = "Maybe It Is",
                Type = "Registro de expressão",
                Year = "2025",
                Description = "Peça criada como forma de expressão pessoal, usando o piano como linguagem para transformar sentimento e observação em música.",
                Tags = new() { "Piano", "Expressão emocional", "2025", "Interpretação" },
                BandLabUrl = "https://www.bandlab.com/track/f1a0f7b2-57ee-f011-8d4d-002248444940?revId=f0a0f7b2-57ee-f011-8d4d-002248444940",
                IsFeatured = false,
                Order = 2
            }
        };

        public static IReadOnlyList<ProjectItem> GetDevelopmentProjects() => _devProjects.AsReadOnly();

        public static IReadOnlyList<CtfCase> GetSecurityCases() => _ctfCases.AsReadOnly();

        public static IReadOnlyList<Composition> GetCompositions() => _compositions.AsReadOnly();
    }
}
