# Assignment 3 – Web Development

**Student Name:** Myungjeong Han  
**Student Number:** 9031031  
**Date:** November 16, 2025  
**Course:** PROG2231 – Programming Microsoft Web Technologies

---

## Assignment Overview

This project is an ASP.NET Core 9 Web API. It shows a many-to-many relationship between students and courses, configured with Fluent API, and supports full CRUD operations. Swagger is used to test all API endpoints.

## Model Overview

1. 2 Main Models

   - Student: Represents a student with properties StudentId, Name, Email, and Major. Each student can take many courses.
   - Course: Represents a course with properties CourseId, CourseName, Credits, and Description. Each course can have many students.

   * Relationship: There is a many-to-many relationship between students and courses. This relationship is handled through an Enrollment table, which was automatically created using Fluent API without adding a separate Enrollment class. For testing, seed data was added to all three tables: Students, Courses, and Enrollment.

2. DTOs (Data Transfer Objects)
   - DTOs are used to send or receive data through the API safely, avoiding unnecessary data and preventing circular references.
   * StudentDto: Returns basic student information safely (ID, Name, Email, Major).
   * StudentCreateDto: Used when creating a new student. Can include a list of course IDs to link courses.
   * StudentUpdateDto: Used when updating a student. Fields are optional for partial updates.
   * CourseDto: Returns basic course information safely (ID, Name, Credits, Description).
   * CourseCreateDto: Used when creating a new course. Can include a list of student IDs to link students.
   * CourseUpdateDto: Used when updating a course. Fields are optional for partial updates.

## Controllers

There are two controllers: StudentsController and CoursesController. Each controller has the basic CRUD operations.
Additionally, special endpoints were added to get related data.
_ /api/Students/{id}/Courses: Returns all courses for a student
_ /api/Courses/{id}/Students: Returns all students for a course

## How to Run

1. Open the project in VS Code
2. Run it using dotnet run
3. Go to the Swagger page in your browser
4. Try out all the API endpoints for Students and Courses(GET/POST/PUT/DELETE)

## Note

- The database uses SQLite and persists data between runs.
- Swagger is set up to easily test all API endpoints.
- DTOs are used for safe data transfer and to prevent circular references.
- Seed data is already set up for Students, Courses, and Enrollment tables.
