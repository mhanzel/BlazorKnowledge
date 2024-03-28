using System;

namespace Core.Shared.Interfaces;

public interface IBaseInformation
{
    int Id { get; }
    DateTime CreatedDateUtc { get; }
    DateTime? UpdatedDateUtc { get; }
}
