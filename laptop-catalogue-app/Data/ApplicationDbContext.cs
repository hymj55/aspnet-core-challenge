namespace PROG2231_Assignment2__9031031_.Data;

using Microsoft.EntityFrameworkCore;
using PROG2231_Assignment2__9031031_.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    public DbSet<Laptop> Laptops { get; set; }

}   