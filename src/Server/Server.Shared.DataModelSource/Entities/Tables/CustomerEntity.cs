using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Shared.DataModelSource.Entities.Abstracts;

namespace Server.Shared.DataModelSource.Entities.Tables;

public class CustomerEntity : BaseEntity
{
    [StringLength(255)]
    public string? FirstName { get; set; }
    [StringLength(255)]
    public string? LastName { get; set; }
    [StringLength(255)]
    public string? Email { get; set; }

    public List<OrderEntity>? Orders { get; set; }
}
