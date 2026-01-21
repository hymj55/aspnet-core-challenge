using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManyToManyAPI.Data;
using ManyToManyAPI.Models;

namespace ManyToManyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses/101/Students
        // Include an endpoint to show linked data /api/courses/101/students returns all students for course #101
        [HttpGet("{id}/students")]   // Sets the URL pattern that the client will request
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsForCourse(int id)
        {
            // Use eager loading('Include') to fetch the course along with their stdents
            var course = await _context.Courses
                                        .Include(c => c.Students)
                                        .FirstOrDefaultAsync(s => s.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            //To solve Object cycle(Circular reference) issue by using DTO before return JSON
            var studentDtos = course.Students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                Name = s.Name,
                Email = s.Email,
                Major = s.Major
            });

            return Ok(studentDtos);

        }


        // GET: api/Courses
        // Returns all courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        // Returns one course by its id
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // This PUT method is implemented to allow partial updates
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseUpdateDto dto)
        {
            // Get the existing course from the database
            var course = await _context.Courses
                                        .Include(c => c.Students)
                                        .FirstOrDefaultAsync(c => c.CourseId == id);
            if (course == null)
                return NotFound();

            // Update fields only if DTO provides new values
            if (!string.IsNullOrEmpty(dto.CourseName))
                course.CourseName = dto.CourseName;

            if (dto.Credits.HasValue)
                course.Credits = dto.Credits.Value;

            if (!string.IsNullOrEmpty(dto.Description))
                course.Description = dto.Description;

            // Update Students if the client provided Student IDs
            if (dto.StudentIds != null)
            {
                var students = await _context.Students
                                            .Where(s => dto.StudentIds.Contains(s.StudentId))
                                            .ToListAsync();
                course.Students = students;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Courses
        // This POST method creates a new course and supports adding students if provided
        // CourseCreateDto is designed to prevent circular references and protect overposting
        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseCreateDto dto)
        {
            // Convert DTO to Course model
            var course = new Course
            {
                CourseName = dto.CourseName,
                Credits = dto.Credits,
                Description = dto.Description
            };

            // Link Students only if the client sent Student IDs
            if (dto.StudentIds != null && dto.StudentIds.Any())
            {
                var students = await _context.Students
                                            .Where(s => dto.StudentIds.Contains(s.StudentId))
                                            .ToListAsync();
                course.Students = students;
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            // Convert Course model to CourseDto for returning (avoids circular reference)
            var courseDto = new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Credits = course.Credits,
                Description = course.Description
            };
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, courseDto);
        }

        // DELETE: api/Courses/5
        // Finds the course by ID and deletes it from the database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
