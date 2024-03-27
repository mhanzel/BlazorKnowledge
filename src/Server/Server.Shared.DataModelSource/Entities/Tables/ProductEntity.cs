using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Shared.DataModelSource.Entities.Abstracts;

namespace Server.Shared.DataModelSource.Entities.Tables;

public class ProductEntity : BaseEntity
{
    [StringLength(255)]
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    [StringLength(255)]
    public string? Description { get; set; }

    public List<OrderDetailEntity>? OrderDetails { get; set; }
}
