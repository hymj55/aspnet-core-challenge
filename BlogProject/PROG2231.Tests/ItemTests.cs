using Xunit;
using PROG2231.Web.Models;
using PROG2231.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace PROG2231.Tests
{
    public class ItemTests
    {
        [Fact]
        public void CanAddAndRetrieveItem()
        {
            // Arrange
            using var db = DbContextFactory.CreateSqliteInMemory();

            var item = new Item
            {
                Title = "Test Title",
                Description = "Test Description"
            };

            // Act
            db.Items.Add(item);
            db.SaveChanges();

            var saved = db.Items.FirstOrDefault();

            // OUTPUT TO SCREEN (Console)
            // Console.WriteLine("=== Saved Item ===");
            // Console.WriteLine($"Id: {saved?.Id}");
            // Console.WriteLine($"Title: {saved?.Title}");
            // Console.WriteLine($"Description: {saved?.Description}");
            // Console.WriteLine($"CreatedAt: {saved?.CreatedAt}");

            // Assert
            Assert.NotNull(saved);
            Assert.Equal("Test Title", saved!.Title);
            Assert.Equal("Test Description", saved.Description);
            Assert.True(saved.Id > 0);
        }
    }
}
