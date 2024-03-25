using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Shared.DataModelSource.Entities.Abstracts;

namespace Server.Shared.DataModelSource.Entities.Tables;

public class OrderDetail : BaseEntity
{
    public int Quantity { get; set; }

    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
    public int OrderId { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
    public int ProductId { get; set; }

}