using System.ComponentModel.DataAnnotations;
using TRunner.Domain.Models.Enums;

namespace TRunner.Domain.Models.Request;

public class UpdateUserRequest
{
    [Required]
    public int UserId { get; set; }
    public string? DisplayName { get; set; }
    public DateTime? Birthday { get; set; }
    public GenderEnums? Gender { get; set; }
    public int? Height { get; set; }
    public double? Weight { get; set; }
    public ImageInfo? Image { get; set; }
    public bool? IsActive { get; set; } = true;
}
