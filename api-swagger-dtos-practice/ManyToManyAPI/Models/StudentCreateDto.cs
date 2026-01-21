namespace ManyToManyAPI.Models
{
    // DTO for creating student
    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Major { get; set; }

        //To receive only CourseIDs for the many-to-many relationship
        // For HTTP POST: ensures CourseIds is never null, defaults to an empty list
        public List<int> CourseIds { get; set; } = new List<int>();
    }
}
