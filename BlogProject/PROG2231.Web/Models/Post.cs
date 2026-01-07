namespace PROG2231.Web.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string Excerpt { get; set; } = "";
        public string Author { get; set; } = "";
        public string PostImage { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
