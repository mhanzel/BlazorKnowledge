using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Shared.DataModelSource;
using Server.Shared.DataModelSource.Entities.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Modules.Job;

//[ApiController]
//[Route("api/[controller]")]
public class TestController : ControllerBase
{
    readonly DBContext DBContext;

    public TestController(DBContext _dBContext)
    {
        DBContext = _dBContext;
    }

    //[HttpGet]
    public async Task<IActionResult> GetTest()
    {
        var result = DBContext.Customer.Select(x => x.FirstName);
        return StatusCode(200, result);
    }
    //[HttpPost]
    public async Task<IActionResult> AddTest()
    {
        DBContext.Customer.Add(new Customer()
        {
            FirstName = "Jan",
            LastName = "Kowal",
            Email = "jan.kowal@gmail.com",
        });
        await DBContext.SaveChangesAsync();
        return StatusCode(200);
    }
    //[HttpDelete]
    public async Task<IActionResult> DeleteTest()
    {
        await DBContext.Customer.ForEachAsync(x =>
        {
            DBContext.Customer.Remove(x);
        });
        await DBContext.SaveChangesAsync();
        return Ok();
    }
}
