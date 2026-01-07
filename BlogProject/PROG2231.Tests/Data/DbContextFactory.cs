using Microsoft.EntityFrameworkCore;
using PROG2231.Web.Data;

namespace PROG2231.Tests
{
    public static class DbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        public static ApplicationDbContext CreateSqliteInMemory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.OpenConnection();     // required for in-memory SQLite
            context.Database.EnsureCreated();      // creates schema

            return context;
        }
    }
}
