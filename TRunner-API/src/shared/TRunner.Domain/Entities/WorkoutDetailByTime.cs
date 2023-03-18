using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(WorkoutDetailByTime))]
public class WorkoutDetailByTime : BaseModel
{
    [Key]
    public int WorkoutDetailByTimeId { get; set; }

    public string WorkoutDetailData { get; set; }

    [ForeignKey(nameof(WorkoutSummary))]
    public int WorkoutSummaryId { get; set; }

    public virtual WorkoutSummary WorkoutSummary { get; set; }

}
