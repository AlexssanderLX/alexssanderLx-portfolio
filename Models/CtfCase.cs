namespace ClientBlog.Models
{
    public class CtfCase
    {
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Platform { get; set; } = "";
        public string Url { get; set; } = "";
        public string? ImagePath { get; set; }
        public string? ImageAlt { get; set; }
        public string? ReportPdfPath { get; set; }
        public string Difficulty { get; set; } = "";
        public string DifficultyClass { get; set; } = "";
        public string Scenario { get; set; } = "";
        public string Vector { get; set; } = "";
        public string Learning { get; set; } = "";
        public string Mitigation { get; set; } = "";
        public List<string> Tags { get; set; } = new();
        public bool IsFeatured { get; set; }
        public int Order { get; set; }
    }
}
