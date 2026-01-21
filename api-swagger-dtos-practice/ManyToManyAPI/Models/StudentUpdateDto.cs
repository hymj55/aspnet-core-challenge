namespace ManyToManyAPI.Models
{
    // DTO for updating student
    public class StudentUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Major { get; set; }

        //To receive only CourseIDs for the many-to-many relationship
        // For HTTP PUT: This is optional update, so keeps existing courses if client doesn't send CourseIds
        // using ? to make it nullable for optional updates
        public List<int>? CourseIds { get; set; }
    }
}
