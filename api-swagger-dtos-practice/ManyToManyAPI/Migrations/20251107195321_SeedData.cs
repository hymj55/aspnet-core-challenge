using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManyToManyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Credits", "Description" },
                values: new object[,]
                {
                    { 101, "Programming 2231", 3, "Intro to programming" },
                    { 102, "Database System", 3, "Learn about No sql" },
                    { 103, "Data Structures and Algorithms", 3, "Learn about DSA" },
                    { 104, "Agile System", 3, "Learn about Agile" },
                    { 105, "Cyber security", 3, "Learn about security" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "Major", "Name" },
                values: new object[,]
                {
                    { 1, "mj@gmail.com", "CPA", "MJ Han" },
                    { 2, "eunwoo@gmail.com", "CP", "Eunwoo Cha" },
                    { 3, "lucas@gmail.com", "CPA", "Lucas Lee" },
                    { 4, "mina@gmail.com", "CP", "Mina Lee" },
                    { 5, "seonmi@gmail.com", "CPA", "Seonmi Kang" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CoursesCourseId", "StudentsStudentId" },
                values: new object[,]
                {
                    { 101, 1 },
                    { 101, 3 },
                    { 102, 1 },
                    { 102, 4 },
                    { 103, 2 },
                    { 103, 4 },
                    { 104, 2 },
                    { 104, 5 },
                    { 105, 3 },
                    { 105, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 101, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 102, 4 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 103, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 103, 4 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 104, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 104, 5 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 105, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CoursesCourseId", "StudentsStudentId" },
                keyValues: new object[] { 105, 5 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);
        }
    }
}
