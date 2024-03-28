using Core.Shared.Interfaces;
using System;

namespace Core.Modules.Job.Interfaces.Models;

public interface ICustomer : IBaseInformation
{
    string? FirstName { get; }
    string? LastName { get; }
    string? Email { get;  }
}
