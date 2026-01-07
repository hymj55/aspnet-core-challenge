using System.Text.Json.Serialization;

namespace PROG2231.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        // Relationships
        [JsonIgnore]    
        // To prevent circular reference when serializing to JSON.
        // Previously used DTOs, here ignoring navigation property suffices.
        public List<Post> Posts { get; set; } = new();
    }
}
