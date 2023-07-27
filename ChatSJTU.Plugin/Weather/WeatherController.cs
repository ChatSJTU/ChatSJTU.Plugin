using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "weather_report",
                    "description": "Get the current weather in a given location",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "location": {
                                "type": "string",
                                "enum": ["minhang", "xuhui"],
                                "description": "The campus of Shanghai Jiao Tong University"
                            }
                        },
                        "required": ["location"]
                    }
                }
                """;
        }

        [HttpPost]
        [Route("report")]
        public FcDto Post([FromBody] WeatherInputDto argv)
        {
            Debug.WriteLine(argv.location);
            if (argv.location == "minhang")
            {
                var res = Web.Get("https://api.openweathermap.org/data/2.5/onecall?lat=31.029527&lon=121.44105&appid=25758ef0e94de8043a21e689e4c88ba5&units=metric&lang=zh_cn", new Dictionary<string, string>());

                var json = JsonConvert.DeserializeObject<WeatherDto>(res.result);

                return new FcDto(0, "", JsonConvert.SerializeObject(json.Current));
            }
            else if (argv.location == "xuhui")
            {
                var res = Web.Get("https://api.openweathermap.org/data/2.5/onecall?lat=31.199251&lon=121.433256&appid=25758ef0e94de8043a21e689e4c88ba5&units=metric&lang=zh_cn", new Dictionary<string, string>());

                var json = JsonConvert.DeserializeObject<WeatherDto>(res.result);

                return new FcDto(0, "", JsonConvert.SerializeObject(json.Current));
            }
            else
            {
                return new FcDto(400, "没有这个校区", null);
            }
        }
    }
}