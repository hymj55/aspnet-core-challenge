using Xunit;
using PROG2231.Web.Models;
using PROG2231.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace PROG2231.Tests
{
    public class CategoryModelTests
    {
        [Fact]
        public void CanAddAndRetrieveCategory()
        {
            // Arrange
            using var db = DbContextFactory.CreateSqliteInMemory();

            var category = new Category { Name = "Programming" };

            // Act
            db.Categories.Add(category);
            db.SaveChanges();

            var saved = db.Categories.FirstOrDefault();

            // OUTPUT TO SCREEN (Console)
            Console.WriteLine("=== Saved Category ===");
            Console.WriteLine($"Id: {saved?.Id}");
            Console.WriteLine($"Name: {saved?.Name}");

            // Assert
            Assert.NotNull(saved);
            Assert.Equal("Programming", saved!.Name);
            Assert.True(saved.Id > 0);
        }
    }
}
