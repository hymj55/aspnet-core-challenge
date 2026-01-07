using System.Text.Json.Serialization;

namespace PROG2231.Web.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [JsonIgnore]
        // To prevent circular reference when serializing to JSON.
        // Previously used DTOs, here ignoring navigation property suffices.
        public List<Post> Posts { get; set; } = new();
    }
}
