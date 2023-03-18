using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(Group))]
public class Group : BaseModel
{
    [Key]
    public int GroupId { get; set; }

    public string GroupUUId { get; set; }

    public string? GroupImageUrl { get; set; }

    public string GroupName { get; set; }

    public string? Description { get; set; }

    public string? Website { get; set; }

    public string? Location { get; set; }

    [ForeignKey(nameof(SportType))]
    public int GroupTypeId { get; set; }

    public int TotalRunner { get; set; } = 0;

    public byte IsPublished { get; set; } = 0;

    public virtual GroupType GroupType { get; set; }

    public virtual ICollection<Sport> Sports { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
