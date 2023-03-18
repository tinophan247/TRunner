using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(WorkoutImage))]
public class WorkoutImage : BaseModel
{
    [Key]
    public int WorkoutImageId { get; set; }

    public string WorkoutImageUrl { get; set; }

    [ForeignKey(nameof(WorkoutSummary))]
    public int WorkoutSummaryId { get; set; }

    public virtual WorkoutSummary WorkoutSummary { get; set; }

}
