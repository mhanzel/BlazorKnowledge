using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Modules.Job.Interfaces.Models;

namespace Server.Shared.DataModelSource.Entities;

public class CustomerEntity : ICustomer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedDateUtc { get; private set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedDateUtc { get; internal set; }

    [StringLength(255)]
    public string? FirstName { get; set; }

    [StringLength(255)]
    public string? LastName { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    public ICollection<OrderEntity>? Orders { get; set; }
}
