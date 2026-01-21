namespace ManyToManyAPI.Models
{
    // DTO for returning course data in API responses
    // Prevents circular reference issues and exposes only necessary fields
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int Credits { get; set; }
        public string? Description { get; set; }

    }
}