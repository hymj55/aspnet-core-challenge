using Microsoft.EntityFrameworkCore;
using ManyToManyAPI.Models;

namespace ManyToManyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure many-to-many relationship between Student and Course
            modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity<Dictionary<string, object>>(
                "Enrollment",
                j => j
                    .HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CoursesCourseId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentsStudentId")
                    .OnDelete(DeleteBehavior.Cascade),

                j =>
                {
                    //Composite primary key on the join table
                    j.HasKey("CoursesCourseId", "StudentsStudentId");

                    //Seed join table(Enrollment) data
                    j.HasData(
                        new { CoursesCourseId = 101, StudentsStudentId = 1 }, 
                        new { CoursesCourseId = 102, StudentsStudentId = 1 }, 
                        new { CoursesCourseId = 103, StudentsStudentId = 2 }, 
                        new { CoursesCourseId = 104, StudentsStudentId = 2 }, 
                        new { CoursesCourseId = 105, StudentsStudentId = 3 }, 
                        new { CoursesCourseId = 101, StudentsStudentId = 3 }, 
                        new { CoursesCourseId = 102, StudentsStudentId = 4 }, 
                        new { CoursesCourseId = 103, StudentsStudentId = 4 }, 
                        new { CoursesCourseId = 104, StudentsStudentId = 5 }, 
                        new { CoursesCourseId = 105, StudentsStudentId = 5 }  
                    );
                }

            );

            // Seed Students data 
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "MJ Han", Email = "mj@gmail.com", Major = "CPA" },
                new Student { StudentId = 2, Name = "Eunwoo Cha", Email = "eunwoo@gmail.com", Major = "CP" },
                new Student { StudentId = 3, Name = "Lucas Lee", Email = "lucas@gmail.com", Major = "CPA" },
                new Student { StudentId = 4, Name = "Mina Lee", Email = "mina@gmail.com", Major = "CP" },
                new Student { StudentId = 5, Name = "Seonmi Kang", Email = "seonmi@gmail.com", Major = "CPA" }
            );

            // Seed Courses data
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 101, CourseName = "Programming 2231", Credits = 3, Description = "Intro to programming" },
                new Course { CourseId = 102, CourseName = "Database System", Credits = 3, Description = "Learn about No sql" },
                new Course { CourseId = 103, CourseName = "Data Structures and Algorithms", Credits = 3, Description = "Learn about DSA" },
                new Course { CourseId = 104, CourseName = "Agile System", Credits = 3, Description = "Learn about Agile" },
                new Course { CourseId = 105, CourseName = "Cyber security", Credits = 3, Description = "Learn about security" }
            );


        }
    }
}