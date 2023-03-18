using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(GroupType))]
public class GroupType : BaseModel
{
    [Key]
    public int GroupTypeId { get; set; }

    public string GroupTypeUUId { get; set; }

    public string GroupTypeName { get; set; }

    public virtual ICollection<Group> Groups { get; set; }

}
