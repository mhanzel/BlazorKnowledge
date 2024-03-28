using Core.Modules.Job.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modules.Job.Model.Models
{
    public record OrderModel : IOrder
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public OrderModel(IOrder order)
        {
            OrderNumber = order.OrderNumber;
            OrderDate = order.OrderDate;
            CustomerId = order.CustomerId;
            Id = order.Id;
            CreatedDateUtc = order.CreatedDateUtc;
            UpdatedDateUtc = order.UpdatedDateUtc;
        }

        public OrderModel() { }
    }
}
