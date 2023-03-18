using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(WorkoutSummary))]
public class WorkoutSummary : BaseModel
{
    [Key]
    public int WorkoutSummaryId { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public int Time { get; set; }

    public double Distance { get; set; }

    public double AvgSpeed { get; set; }

    public string StartTime { get; set; }

    public string EndTime { get; set; }

    [ForeignKey(nameof(UserRole))]
    public int UserRoleId { get; set; }

    [ForeignKey(nameof(Sport))]
    public int SportId { get; set; }

    [ForeignKey(nameof(ViewPermissionType))]
    public int ViewPermissionTypeId { get; set; }

    public virtual UserRole UserRole { get; set; }

    public virtual Sport Sport { get; set; }

    public virtual ViewPermissionType ViewPermissionType { get; set; }

    public virtual WorkoutDetailByTime WorkoutDetailByTime { get; set; }

    public virtual ICollection<WorkoutImage> WorkoutImages { get; set; }
}
