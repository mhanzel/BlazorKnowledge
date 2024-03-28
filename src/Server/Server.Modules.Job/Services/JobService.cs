using Core.Modules.Job.Model.Models;
using Core.Modules.Job.Model.Queries;
using Microsoft.EntityFrameworkCore;
using Server.Modules.Job.Interfaces;
using Server.Shared.DataModelSource;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Modules.Job.Services;

public class JobService : IJobService
{
    readonly DBContext DBContext;

    public JobService(DBContext dBContext)
    {
        DBContext = dBContext;
    }

    public async Task<GetCustomersQueryResult> GetCustomersAsync(GetCustomersQueryParameters query, CancellationToken cancellationToken = default)
    {
        var customers = await DBContext.Customer.ToListAsync(cancellationToken);
        var customersMapped = customers.Select(customer => new CustomerModel(customer));
        return new GetCustomersQueryResult(customersMapped);
    }

    public async Task<GetOrdersQueryResult> GetOrdersAsync(GetOrdersQueryParameters query, CancellationToken cancellationToken = default)
    {
        var orders = await DBContext.Order.ToListAsync(cancellationToken);
        var ordersMapped = orders.Select(order => new OrderModel(order));
        return new GetOrdersQueryResult(ordersMapped);
    }

    public async Task<GetProductsQueryResult> GetProductsAsync(GetProductsQueryParameters query, CancellationToken cancellationToken = default)
    {
        var products = await DBContext.Product.ToListAsync(cancellationToken);
        var productsMapped = products.Select(product => new ProductModel(product));
        return new GetProductsQueryResult(productsMapped);
    }
}
