namespace ClientBlog.Models
{
    public class Composition
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Year { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Tags { get; set; } = new();
        public string? BandLabUrl { get; set; }
        public bool IsFeatured { get; set; }
        public int Order { get; set; }
    }
}
