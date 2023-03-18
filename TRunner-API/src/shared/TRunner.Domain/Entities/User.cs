using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;
using TRunner.Domain.Models.Enums;

namespace TRunner.Domain.Entities;

[Table(nameof(User))]
public class User : BaseModel
{
    [Key]
    public int UserId { get; set; }

    public string Email { get; set; }

    public string? DisplayName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; } = GenderEnums.NotToSay.ToString();

    public int? Height { get; set; }

    public double? Weight { get; set; }

    public string? ImageUrl { get; set; }

    [ForeignKey(nameof(UserRole))]
    public int UserRoleId { get; set; }

    public byte IsRunner { get; set; } = 1;

    public string PasswordHash { get; set; }

    public virtual UserRole UserRole { get; set; }

    public virtual ICollection<Group> Groups { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
}
