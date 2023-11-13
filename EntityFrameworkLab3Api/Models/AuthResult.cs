using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLab3Api.Models;

public class AuthResult
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}