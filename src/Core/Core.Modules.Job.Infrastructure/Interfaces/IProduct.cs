using Core.Shared.Interfaces;
using System;

namespace Core.Modules.Job.Interfaces.Models;

public interface IProduct : IBaseInformation
{
    public string? ProductName { get; }
    public decimal Price { get; }
    public string? Description { get; }
}
