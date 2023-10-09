using Microsoft.AspNetCore.Mvc;
using System.Text;


using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Components.Routing;
using static webapi.Rover;

namespace webapi.Controllers;

[ApiController]
public class MissionController : ControllerBase
{


    /*    private readonly ILogger<WeatherForecastController> _logger;


        public MissionController(ILogger<MissionController> logger)
        {
            _logger = logger;
        }*/


    private async Task<string> ReadRequestBodyAsync(HttpRequest request)
    {
        using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
        {
            return await reader.ReadToEndAsync();
        }
    }

    [Route("[controller]")]
    [HttpGet]
    public IEnumerable<string> Get()
    {
       return new string[] {"ij","ok"};
    }

    [Route("[controller]")]
    [HttpPost]
    public async Task<IActionResult> onPostAsync()
    {
        List<Rover> list = new List<Rover>(); // this is our return type

        string requestBody = await ReadRequestBodyAsync(Request);

        string unescapedBody = JsonSerializer.Deserialize<string>(requestBody);

        string[] lines = unescapedBody.Split(new string[] { "\r\n", "\r", "\n"}, StringSplitOptions.None);

        int[] mapBoundary = lines[0].Split(' ').Select(int.Parse).ToArray();

        Map map = new Map(mapBoundary[0], mapBoundary[1]);

        for (int i = 1; i < lines.Count(); i+=2)
        {

            //secion 1
            // we are grabbing two at a time an incrimenting +=2 

            string[] position = lines[i].Split(' ');
            Heading heading = (Heading)Enum.Parse(typeof(Heading), position[2]);
            Rover rover = new Rover(map);
            rover.x = int.Parse(position[0]);
            rover.y = int.Parse(position[1]);
            rover.heading = heading;

            // section 2
            // we are grabbing two at a time an incrimenting +=2 
            // move instructions here
            string instructions = lines[i + 1];
            rover.Move(instructions);

            list.Add(rover);
        }


        return Ok(list);
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


}
