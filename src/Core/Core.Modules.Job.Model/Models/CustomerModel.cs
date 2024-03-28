using Core.Modules.Job.Interfaces.Models;
using System;

namespace Core.Modules.Job.Model.Models
{
    public record CustomerModel : ICustomer
    {
        public int Id { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime? UpdatedDateUtc { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public CustomerModel(ICustomer customer)
        {
            Id = customer.Id;
            CreatedDateUtc = customer.CreatedDateUtc;
            UpdatedDateUtc = customer.UpdatedDateUtc;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
        }

        public CustomerModel() { }
    }
}
