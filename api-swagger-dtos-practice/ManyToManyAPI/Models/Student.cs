namespace ManyToManyAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Major{ get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}