namespace Midterm_9031031.Data;

using Microsoft.EntityFrameworkCore;
using Midterm_9031031.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    public DbSet<Clothing> Clothings { get; set; }


}