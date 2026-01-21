using Microsoft.EntityFrameworkCore;
using PlantApi.Models;

namespace PlantApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Plant> Plants { get; set; }
    }
}