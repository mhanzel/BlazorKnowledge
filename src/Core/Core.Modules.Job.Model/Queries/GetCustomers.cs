using Core.Modules.Job.Model.Models;
using System.Collections;
using System.Collections.Generic;

namespace Core.Modules.Job.Model.Queries;

public record GetCustomersQueryParameters();
public record GetCustomersQueryResult(IEnumerable<CustomerModel> customer);