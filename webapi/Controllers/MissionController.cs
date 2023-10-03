using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace webapi.Controllers;

    [ApiController]
    [Route("[controller]")]
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




    public IActionResult Get()
    {
        //Mission = new Mission();
        Map map = new Map(5,5);

        return Ok(map);
    }
/*    }
    [HttpGet]
    public ActionResult MissionController
    {
        return Ok(("hello);
    }*/
}


