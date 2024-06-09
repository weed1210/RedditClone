using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reddit.Domain.Entities.Abstractions;
public abstract class BaseEntity
{
    public BaseEntity()
    {
        DateCreated = DateTime.Now;
        DateUpdated = DateTime.Now;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
