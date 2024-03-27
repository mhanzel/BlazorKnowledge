using Microsoft.AspNetCore.Mvc;
using Server.Shared;
using Server.Shared.DataModelSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Modules.Job
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : HandlerControllerBase
    {
        readonly DBContext DBContext;

        public JobController(DBContext _dBContext)
        {
            DBContext = _dBContext;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = DBContext.Customer.ToList();
            return StatusCode(200, result);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = DBContext.Order.ToList();
            return StatusCode(200, result);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = DBContext.Product.ToList();
            return StatusCode(200, result);
        }

    }
}
