using Xunit;
using Microsoft.AspNetCore.Mvc;
using PROG2231.Web.Controllers;
using PROG2231.Web.Data;
using PROG2231.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace PROG2231.Tests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithCategories()
        {
            // Arrange
            using var db = DbContextFactory.CreateSqliteInMemory();
            db.Categories.Add(new Category { Name = "Programming" });
            db.Categories.Add(new Category { Name = "Tools" });
            db.SaveChanges();

            var controller = new CategoriesController(db);

            // Act
            var result = await controller.Index();

            // OUTPUT TO SCREEN (Console)
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.Model);

            Console.WriteLine("=== Categories in Index ===");
            foreach (var category in model)
            {
                Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
            }

            // Assert
            Assert.Equal(2, model.Count);
        }
    }
}
