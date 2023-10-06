using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace webapi.Controllers;

[ApiController]
public class MissionController : ControllerBase
{

    //        [HttpGet(Name = "SetParameters")]
    //        public IEnumerable<WeatherForecast> Set()
    //        {
    //            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //            {
    //                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //                TemperatureC = Random.Shared.Next(-20, 55),
    //                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    ///            })
    //           .ToArray();
    //       }



    /*    [Route("[controller]")]
        public ActionResult Get()
        {
            //Mission = new Mission();
            //Map map = new Map(5, 5);

            return Ok("hello");
        }*/
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

    [Route("[controller]/[action]")]
    [HttpPost]
    public ActionResult Map(string data)
    {
        return Ok(data);
    }

/*    [HttpGet]
    public ActionResult MissionController
    {
         return Ok("hello);
    }*/

}
