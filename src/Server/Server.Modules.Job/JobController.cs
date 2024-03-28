using Core.Modules.Job.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Server.Modules.Job.Interfaces;
using Server.Shared;
using Server.Shared.DataModelSource;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Modules.Job;

[ApiController]
[Route("api/[controller]")]
public class JobController : HandlerControllerBase
{
    readonly IJobService JobService;

    public JobController(IJobService jobService)
    {
        JobService = jobService;
    }

    [HttpPost("GetCustomers")]
    public async Task<ActionResult<GetCustomersQueryResult>> GetCustomers(GetCustomersQueryParameters parameter, CancellationToken cancellationToken = default)
        => await ExecuteAsync(async () => await JobService.GetCustomersAsync(parameter, cancellationToken));
    
    [HttpPost("GetOrders")]
    public async Task<ActionResult<GetOrdersQueryResult>> GetOrders(GetOrdersQueryParameters parameter, CancellationToken cancellationToken = default)
        => await ExecuteAsync(async () => await JobService.GetOrdersAsync(parameter, cancellationToken));

    [HttpPost("GetProducts")]
    public async Task<ActionResult<GetProductsQueryResult>> GetProducts(GetProductsQueryParameters parameter, CancellationToken cancellationToken = default)
        => await ExecuteAsync(async () => await JobService.GetProductsAsync(parameter, cancellationToken));
}
