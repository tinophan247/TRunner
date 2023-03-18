using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(ViewPermissionType))]
public class ViewPermissionType : BaseModel
{
    [Key]
    public int ViewPermissionTypeId { get; set; }

    public string ViewPermissionTypeUUId { get; set; }

    public string ViewPermission { get; set; }

    public virtual ICollection<WorkoutSummary> WorkoutSummaries { get; set; }

}
