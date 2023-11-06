using EntityFrameworkLab3Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab3Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        // Define relationship between books and authors
        builder.Entity<Book>()
            .HasOne(x => x.Author)
            .WithMany(x => x.Books);

        builder.Entity<Product>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Products);

        // Seed database with authors and books for demo
        new DbInitializer(builder).Seed();
    }
}