using EntityFrameworkLab3Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab3Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Product>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Products);
    }
}