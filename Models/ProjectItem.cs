namespace ClientBlog.Models
{
    public class ProjectItem
    {
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Rank { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Description { get; set; } = "";
        public string? ImagePath { get; set; }
        public string? ImageAlt { get; set; }
        public List<string> Tags { get; set; } = new();
        public string? GitHubUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool ContentConfirmed { get; set; } = true;
        public string Status { get; set; } = "active";
        public int Order { get; set; }
    }
}
