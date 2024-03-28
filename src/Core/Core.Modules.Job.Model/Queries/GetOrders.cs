using Core.Modules.Job.Model.Models;
using System.Collections.Generic;

namespace Core.Modules.Job.Model.Queries;

public record GetOrdersQueryParameters();
public record GetOrdersQueryResult(IEnumerable<OrderModel> order);