namespace ManyToManyAPI.Models
{
    public class CourseCreateDto
    {
        public string? CourseName { get; set; }
        public int Credits { get; set; }
        public string? Description { get; set; }

        // To link existing students with this new course only if provided
        public List<int> StudentIds { get; set; } = new List<int>();
    }
}