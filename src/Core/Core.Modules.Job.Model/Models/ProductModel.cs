using Core.Modules.Job.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modules.Job.Model.Models
{
    public record ProductModel : IProduct
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public ProductModel(IProduct product)
        {
            Id = product.Id;
            CreatedDateUtc = product.CreatedDateUtc;
            UpdatedDateUtc = product.UpdatedDateUtc;
            ProductName = product.ProductName;
            Price = product.Price;
            Description = product.Description;
        }

        public ProductModel() { }
    }
}
