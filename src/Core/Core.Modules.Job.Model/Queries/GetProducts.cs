using Core.Modules.Job.Model.Models;
using System.Collections.Generic;

namespace Core.Modules.Job.Model.Queries;

public record GetProductsQueryParameters();
public record GetProductsQueryResult(IEnumerable<ProductModel> product);