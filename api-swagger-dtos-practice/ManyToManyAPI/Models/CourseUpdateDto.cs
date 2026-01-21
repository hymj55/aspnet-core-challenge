namespace ManyToManyAPI.Models
{
    public class CourseUpdateDto
    {
        public string? CourseName { get; set; }
        
        // Make Credits property nullable, 
        // so we can know if the client wants to update this field or not
        public int? Credits { get; set; }
        public string? Description { get; set; }

        // To update linked students only if provided
        public List<int>? StudentIds { get; set; }
    }
}