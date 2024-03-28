using Core.Shared.Interfaces;
using System;

namespace Core.Modules.Job.Interfaces.Models;

public interface IOrderDetail : IBaseInformation
{
    public int Quantity { get; }
    public int OrderId { get; }
    public int ProductId { get; }
}
