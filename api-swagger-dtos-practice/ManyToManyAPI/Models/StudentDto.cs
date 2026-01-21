namespace ManyToManyAPI.Models
{
    // DTO for returning student data in API responses
    // Prevents circular reference issues and exposes only necessary fields
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Major { get; set; }

    }
}