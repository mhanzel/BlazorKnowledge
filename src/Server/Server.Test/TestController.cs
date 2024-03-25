using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Shared.DataModelSource;
using System.Collections.Generic;
using System.Linq;

namespace Server.Modules.Job;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    readonly DBContext DBContext;

    public TestController(DBContext _dBContext)
    {
        DBContext = _dBContext;
    }

    [HttpGet]
    public IActionResult GetTest()
    {
        var result = DBContext.Customer.Select(x => x.FirstName);
        return Ok(result);
    }
    [HttpPost]
    public IActionResult AddTest()
    {
        DBContext.Customer.Add(new Shared.DataModelSource.Entities.Tables.Customer()
        {
            FirstName = "Jan",
            LastName = "Kowal",
            Email = "jan.kowal@gmail.com",
        });
        DBContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteTest()
    {
        DBContext.Customer.ForEachAsync(x =>
        {
            DBContext.Customer.Remove(x);
        });
        DBContext.SaveChangesAsync();
        return Ok();
    }
}
