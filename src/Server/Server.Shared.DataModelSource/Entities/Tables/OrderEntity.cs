using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Shared.DataModelSource.Entities.Abstracts;

namespace Server.Shared.DataModelSource.Entities.Tables;

public class OrderEntity : BaseEntity
{
    [StringLength(255)]
    public string? OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }

    [ForeignKey("CustomerId")]
    public CustomerEntity? Customer { get; set; }
    public int CustomerId { get; set; }

    public List<OrderDetailEntity>? OrderDetails { get; set; }
}
