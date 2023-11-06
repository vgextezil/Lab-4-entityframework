using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLab3Api.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public string? Properties { get; set; }

    public List<Product>? Products { get; set; } = new List<Product>();

}