using System.ComponentModel.DataAnnotations;

namespace TRunner.Domain.Models.Request;

public class AuthenticateRequest
{
    [Required]
    public bool IsRunner { get; set; } = true;

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
