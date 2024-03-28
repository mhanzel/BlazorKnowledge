using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Modules.Job.Interfaces.Models;

namespace Server.Shared.DataModelSource.Entities;

public class OrderEntity : IOrder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedDateUtc { get; private set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedDateUtc { get; internal set; }

    [StringLength(255)]
    public string? OrderNumber { get; set; }

    public DateTime OrderDate { get; set; }

    [ForeignKey("CustomerId")]
    public CustomerEntity? Customer { get; set; }

    public int CustomerId { get; set; }

    public ICollection<OrderDetailEntity>? OrderDetails { get; set; }
}
