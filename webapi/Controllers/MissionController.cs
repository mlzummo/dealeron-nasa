using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace webapi.Controllers;

[ApiController]
public class MissionController : ControllerBase
{
    [Route("[controller]")]
    [HttpGet]
    public IEnumerable<string> Get()
    {
       return new string[] {"ij","ok"};
    }

    [Route("[controller]/[action]")]
    [AcceptVerbs("GET")]
    [HttpGet]
    public ActionResult Map()
    {
        Map map = new Map(5, 5);
        return new JsonResult(map);
    }

/*    [Route("[controller]/[action]")]
    [HttpPost]
    public ActionResult Map(string data)
    {
        return Ok(data);
    }*/
}
