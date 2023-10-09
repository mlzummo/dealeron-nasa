﻿using Microsoft.AspNetCore.Mvc;
using System.Text;


using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using static webapi.Location;
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



        /*        var body = Request.Body;
        */

        string requestBody = await ReadRequestBodyAsync(Request);


        string unescapedBody = JsonSerializer.Deserialize<string>(requestBody);


        /*
                string[] lines = unescapedBody.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );*/

        string[] lines = unescapedBody.Split(new string[] { "\r\n", "\r", "\n"}, StringSplitOptions.None);

        int[] mapBoundary = lines[0].Split(' ').Select(int.Parse).ToArray();

        /*        try
                {


                } catch (Exception ex)
                {
                    //todo: throw error to console
                }*/

        Map map = new Map(mapBoundary[0], mapBoundary[1]);


        for (int i = 1; i < lines.Count(); i+=2)
        {

            //secion 1
            // we are grabbing two at a time an incrimenting +=2 
            // lets create a location struct, with all the goodies ( see LocationStruct.cs for details)

            /*            string[] position = lines[i].Split(' ');
                        Orientation orientation = (Orientation)Enum.Parse(typeof(Orientation), position[2]);
                        Location roverLocation = new Location(orientation, int.Parse(position[0]), int.Parse(position[1]));
                        Rover rover = new Rover(roverLocation);*/

            string[] position = lines[i].Split(' ');
            Heading heading = (Heading)Enum.Parse(typeof(Heading), position[2]);
           /* Location roverLocation = new Location(heading, int.Parse(position[0]), int.Parse(position[1]));*/
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


 /*       int[] result = lines[0].Split(' ').Select(int.Parse).ToArray();*/

        /*        int[] split = lines[0].Split(
                  new string[] { " " },
                  StringSplitOptions.None
                );*/



        /*        Rover rover = new Rover(x, y, heading);
                rover.move("LMLMLMLMM");*/



        /*Mission mission = new Mission(map);*/





        /*     var rawRequestBody = await Request.GetRawBodyAsync();

                 var rawMessage = await Request.Content.ReadAsStringAsync();
     */



        return Ok(list);
        /*string jsonString = JsonSerializer.Serialize(Request.ToString());
        return Ok(new JsonResult(jsonString));
        // Get the request object.
        HttpRequest request = HttpContext.Request;

        var content = await Response.Body.WriteAsync();
        var jsonSerializer = new System.Text.Json.JsonSerializer();
        var obj = await jsonSerializer.DeserializeAsync<MyObject>(response.Body);

        string jsonString = JsonSerializer.Serialize(Request);

        var obj = JsonSerializer.DeserializeAsync<HttpRequest>(response.body);

        var obj = JsonSerializer.Serialize(dataArray);
        return Ok(obj);*/

    }

    /*    public void ProcessRequest(HttpContext context)
        {
            // Check if the request is a POST request
            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                // Read the request body stream
                using (Stream body = context.Request.InputStream)
                {
                    Encoding encoding = context.Request.ContentEncoding;
                    StreamReader reader = new StreamReader(body, encoding);
                    if (context.Request.ContentType != null)
                    {
                        // Get the POST data as a string
                        string postData = reader.ReadToEnd();

                        // Now 'postData' contains the POST data as a string
                        context.Response.Write(postData);
                    }
                }
            }*/

    /*    [HttpPost]
        *//*    public IActionResult Index([FromBody] MyPostRequest request)*//*
        public IActionResult Index()
        {
            // Serialize the POST request body to JSON.
            var jsonString = JsonSerializer.Serialize(Request);

            return Ok(jsonString);
        }*/

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
