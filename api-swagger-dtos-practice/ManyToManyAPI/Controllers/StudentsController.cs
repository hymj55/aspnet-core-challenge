using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManyToManyAPI.Data;
using ManyToManyAPI.Models;
using SQLitePCL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ManyToManyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Students/1/Courses
        // Include an endpoint to show linked data /api/students/1/courses returns all courses for student Id:'1'(for example)
        [HttpGet("{id}/courses")]   // Sets the URL pattern that the client will request
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCoursesForStudent(int id)
        {
            // Use eager loading('Include') to fetch the student along with their courses
            var student = await _context.Students
                                        .Include(s => s.Courses)
                                        .FirstOrDefaultAsync(s => s.StudentId == id);


            if (student == null)
            {
                return NotFound();
            }

            //To solve Object cycle(Circular reference) issue by using DTO before return JSON
            var courseDtos = student.Courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Credits = c.Credits,
                Description = c.Description
            });

            return Ok(courseDtos);

        }


        // GET: api/Students
        // Returns all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        // Returns one student by its id
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // This PUT method is implemented to allow partial updates
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentUpdateDto dto)
        {
            // Get the existing student from the database
            var student = await _context.Students
                                        .Include(s => s.Courses) // Include related Courses
                                        .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound();

            // Update the student only if the DTO provides new values
            if (!string.IsNullOrEmpty(dto.Name))
                student.Name = dto.Name;

            if (!string.IsNullOrEmpty(dto.Email))
                student.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.Major))
                student.Major = dto.Major;

            // Update Courses if the client provided Course IDs
            if (dto.CourseIds != null)
            {
                var courses = await _context.Courses
                                            .Where(c => dto.CourseIds.Contains(c.CourseId))
                                            .ToListAsync();
                student.Courses = courses;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Students
        // This POST method creates a new student and supports adding courses if provided
        // StudentCreateDto is designed to prevent circular references and protect from sending too much data (Overposting)
        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentCreateDto dto)
        {
            // Convert DTO to Student model
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Major = dto.Major
            };

            // Link Courses only if the client sent Course IDs
            if (dto.CourseIds != null && dto.CourseIds.Any())
            {
                var courses = await _context.Courses
                                            .Where(c => dto.CourseIds.Contains(c.CourseId))
                                            .ToListAsync();
                student.Courses = courses;
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Convert Student model to StudentDto for returning (avoids circular reference)
            var studentDto = new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major
            };

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, studentDto);
        }


        // DELETE: api/Students/5
        // Finds the student by ID and deletes it from the database.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
