using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Modules.Job.Interfaces.Models;

namespace Server.Shared.DataModelSource.Entities;

public class OrderDetailEntity : IOrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedDateUtc { get; private set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedDateUtc { get; internal set; }

    public int Quantity { get; set; }

    [ForeignKey("OrderId")]
    public OrderEntity? Order { get; set; }

    public int OrderId { get; set; }

    [ForeignKey("ProductId")]
    public ProductEntity? Product { get; set; }

    public int ProductId { get; set; }
}