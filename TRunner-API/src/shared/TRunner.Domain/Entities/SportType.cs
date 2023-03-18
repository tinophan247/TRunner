using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRunner.Domain.Models;

namespace TRunner.Domain.Entities;

[Table(nameof(SportType))]
public class SportType : BaseModel
{
    [Key]
    public int SportTypeId { get; set; }

    public string SportTypeUUId { get; set; }

    public string SportTypeName { get; set; }

    public virtual ICollection<Sport> Sports { get; set; }

}
