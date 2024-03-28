using Core.Shared.Interfaces;
using System;

namespace Core.Modules.Job.Interfaces.Models;

public interface IOrder : IBaseInformation
{
    public string? OrderNumber { get; }
    public DateTime OrderDate { get; }
    public int CustomerId { get; }
}
