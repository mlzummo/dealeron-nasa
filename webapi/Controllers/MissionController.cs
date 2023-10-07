using Microsoft.AspNetCore.Mvc;
using System.Text;


using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

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

        try
        {
            Map map = new Map(mapBoundary[0], mapBoundary[1]);

        } catch (Exception ex)
        {
            //todo: throw error to console
        }



        for (int i = 1; i < lines.Count(); i+=2)
        {
            string[] position = lines[i].Split(' ');
           /* string[] instructions = lines[i+1].Split(' ');*/

            Rover rover = new Rover(position[0], position[1], position[3]);
        }


        int[] result = lines[0].Split(' ').Select(int.Parse).ToArray();

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



        return Ok(map);
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
