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
                Difficulty = "Médio",
                DifficultyClass = "medium",
                Scenario = "Aplicação web com múltiplos pontos de entrada sujeitos a injeção de dados.",
                Vector = "Mapeamento de comportamento da aplicação, identificação de parâmetros vulneráveis e encadeamento de técnicas de injeção para comprometer a sessão.",
                Learning = "Compreensão profunda de como injeção funciona além do básico: contextos diferentes, filtros insuficientes e bypasses.",
                Mitigation = "Queries parametrizadas, sanitização por contexto, validação rigorosa de entrada e WAF bem configurado.",
                Tags = new() { "Injeção", "Web", "Auth bypass" },
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
                Difficulty = "Médio",
                DifficultyClass = "medium",
                Scenario = "Aplicação web com fluxo de autenticação com controles insuficientes.",
                Vector = "Análise do fluxo de autenticação, identificação de fraqueza no controle de sessão e escalada para execução remota de código.",
                Learning = "Autenticação multi-etapas falha quando apenas uma camada é verificada. Entender o fluxo completo revela pontos cegos.",
                Mitigation = "Verificação de estado em cada etapa, expiração de tokens, limitação de tentativas e logging de eventos de autenticação.",
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
                Difficulty = "Médio",
                DifficultyClass = "medium",
                Scenario = "Desafio web com múltiplas superfícies de ataque e enumeração necessária.",
                Vector = "Enumeração estruturada de diretórios, parâmetros e endpoints antes de escolher o vetor de exploração correto.",
                Learning = "Reconhecimento metódico evita desperdício de tempo. Padrões de comportamento da aplicação revelam a superfície real antes de qualquer exploit.",
                Mitigation = "Remoção de arquivos desnecessários, tratamento de erros que não exponha informações internas e controle de acesso consistente.",
                Tags = new() { "Enumeração", "Web", "Exploração" },
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
                Difficulty = "Fácil",
                DifficultyClass = "easy",
                Scenario = "Lab clássico com enumeração web e escalada de privilégios em Linux.",
                Vector = "Encadeamento de pequenas descobertas: exposição de informações na aplicação, execução de comandos e escalada de privilégios no servidor.",
                Learning = "Pequenas exposições se encadeiam. Um comentário HTML, um arquivo esquecido e permissões frouxas podem ser suficientes.",
                Mitigation = "Remoção de informações de debug, princípio do menor privilégio e revisão de configuração do servidor web.",
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
                Difficulty = "Médio",
                DifficultyClass = "medium",
                Scenario = "Lab com desafio criptográfico e escalada para execução remota de código.",
                Vector = "Análise de tokens criptográficos, recuperação de chaves e interpretação técnica que conecta ao vetor de RCE.",
                Learning = "Criptografia mal implementada é uma falsa sensação de segurança. Chaves fracas, algoritmos obsoletos e contextos misturados criam vetores reais.",
                Mitigation = "Algoritmos modernos, gestão segura de chaves, separação de contextos e validação do lado servidor.",
                Tags = new() { "Criptografia", "RCE", "Análise" },
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
                Difficulty = "Fácil",
                DifficultyClass = "easy",
                Scenario = "Servidor com versão vulnerável do Webmin exposta.",
                Vector = "Identificação de versão, mapeamento da CVE conhecida e exploração controlada do Webmin em ambiente de laboratório.",
                Learning = "Softwares desatualizados com painel de administração exposto são alvos diretos. Versão + CVE = vetor imediato.",
                Mitigation = "Manutenção contínua, atualizações de segurança, restrição de acesso ao painel administrativo e varreduras periódicas.",
                Tags = new() { "CVE", "Enumeração", "RCE" },
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
                Difficulty = "Fácil",
                DifficultyClass = "easy",
                Scenario = "Lab baseado em CVE recente com foco em RCE e contorno de restrições.",
                Vector = "Exploração de vulnerabilidade recente, bypass de restrições do sistema e escalada de privilégios em ambiente controlado.",
                Learning = "CVEs recentes têm janelas curtas de exploração. Entender a causa raiz da vulnerabilidade importa mais do que o exploit em si.",
                Mitigation = "Monitoramento de CVEs, patch management estruturado e hardening do sistema operacional.",
                Tags = new() { "CVE recente", "PrivEsc", "RCE" },
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
