using Core.Modules.Job.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modules.Job.Model.Models
{
    public record OrderDetailModel : IOrderDetail
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public OrderDetailModel(IOrderDetail orderDetail)
        {
            Id = orderDetail.Id;
            CreatedDateUtc = orderDetail.CreatedDateUtc;
            UpdatedDateUtc = orderDetail.UpdatedDateUtc;
            Quantity = orderDetail.Quantity;
            OrderId = orderDetail.OrderId;
            ProductId = orderDetail.ProductId;
        }

        public OrderDetailModel() { }
    }
}
