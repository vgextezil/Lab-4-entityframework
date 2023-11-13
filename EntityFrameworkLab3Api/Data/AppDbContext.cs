using EntityFrameworkLab3Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab3Api.Data;

public class AppDbContext : IdentityDbContext
{    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    /*
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Product>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Products);

    }
    */
}