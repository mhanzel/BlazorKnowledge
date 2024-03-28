using Core.Modules.Job.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Server.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Modules.Job.Interfaces;

public interface IJobService : IServiceRegistration
{
    public Task<GetCustomersQueryResult> GetCustomersAsync(GetCustomersQueryParameters query, CancellationToken cancellationToken = default);
    public Task<GetOrdersQueryResult> GetOrdersAsync(GetOrdersQueryParameters query, CancellationToken cancellationToken = default);
    public Task<GetProductsQueryResult> GetProductsAsync(GetProductsQueryParameters query, CancellationToken cancellationToken = default);
}