using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(UserRole))]
public class UserRole : BaseModel
{
    [Key]
    public int UserRoleId { get; set; }

    public string UserRoleUUId { get; set; }

    public string RoleName { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
