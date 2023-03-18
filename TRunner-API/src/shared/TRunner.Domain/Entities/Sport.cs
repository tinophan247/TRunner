using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(Sport))]
public class Sport : BaseModel
{
    [Key]
    public int SportId { get; set; }

    public string? ImageUrl { get; set; }

    public string? SportName { get; set; }

    [ForeignKey(nameof(SportType))]
    public int SportTypeId { get; set; }

    public virtual SportType SportType { get; set; }

    public virtual ICollection<Group> Groups { get; set; }
}
