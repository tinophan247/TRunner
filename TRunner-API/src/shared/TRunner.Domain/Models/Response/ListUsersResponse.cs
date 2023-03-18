using TRunner.Domain.Models.Enums;

namespace TRunner.Domain.Models.Response;

public class ListUsersResponse
{
    public List<UserResponse> Users { get; set; } = new List<UserResponse>();
    public int TotalRow { get; set; }
}

public class UserResponse
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string? DisplayName { get; set; }
    public DateTime? Birthday { get; set; }
    public GenderEnums? Gender { get; set; }
    public int? Height { get; set; }
    public double? Weight { get; set; }
    public string? ImageUrl { get; set; }
    public int UserRoleId { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
