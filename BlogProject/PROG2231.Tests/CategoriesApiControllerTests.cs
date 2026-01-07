using Xunit;
using PROG2231.Web.Models;
using PROG2231.Web.Data;
using PROG2231.Web.Controllers.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace PROG2231.Tests
{
    public class CategoriesApiControllerTests
    {
        [Fact]
        public async Task CanGetAllCategories()
        {
            // Arrange
            using var db = DbContextFactory.CreateSqliteInMemory();

            var cat1 = new Category { Name = "Programming" };
            var cat2 = new Category { Name = "Tools" };

            db.Categories.AddRange(cat1, cat2);
            db.SaveChanges();

            var controller = new CategoriesApiController(db);

            // Act
            var result = await controller.GetAll();

            // OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);
            var categories = Assert.IsType<List<Category>>(okResult.Value);

            // OUTPUT TO SCREEN (Console)
            Console.WriteLine("=== Categories from API ===");
            foreach (var cat in categories)
            {
                Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
            }

            // Assert
            Assert.Equal(2, categories.Count);
            Assert.Contains(categories, c => c.Name == "Programming");
            Assert.Contains(categories, c => c.Name == "Tools");
        }
    }
}
