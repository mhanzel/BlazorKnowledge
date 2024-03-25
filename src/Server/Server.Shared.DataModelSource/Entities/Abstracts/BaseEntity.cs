using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Server.Shared.DataModelSource.Entities.Abstracts;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    public DateTime CreatedDateUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedDateUtc { get; internal set; }
}
