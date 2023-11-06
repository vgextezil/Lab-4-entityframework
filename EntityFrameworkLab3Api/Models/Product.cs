using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLab3Api.Models;

public class Product
{
    [Key] public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}