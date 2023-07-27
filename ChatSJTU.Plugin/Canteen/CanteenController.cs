using ChatSJTU.Plugin.Canteen;
using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("canteen")]
    public class CanteenController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<CanteenController> _logger;

        public CanteenController(ILogger<CanteenController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "canteen_heatmap",
                    "description": "Get restaurant traffic information",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "name": {
                                "type": "string",
                                "description": "The name of restaurant"
                            },
                            "available_seat": {
                                "type": "number",
                                "description": "The number of available seats in the restaurant"
                            },
                            "total_seat": {
                                "type": "number",
                                "description": "The number of total seats in the restaurant"
                            },
                            "occupancy_rate": {
                                "type": "number",
                                "description": "The occupancy rate of the restaurant"
                            }
                        },
                        "required": []
                    }
                }
                """;
        }

        [HttpPost]
        [Route("heatmap")]
        public FcDto GetHeatMap()
        {
            //Debug.WriteLine(argv.location);
            var res = Web.Get("https://canteen.sjtu.edu.cn/CARD/Ajax/Place", new Dictionary<string, string>());
            if (res.success)
            {
                var json = JsonConvert.DeserializeObject<List<CanteenHeatmapDto>>(res.result);
                List<CanteenHeatmapOutputDto> outputDto = new List<CanteenHeatmapOutputDto>();
                foreach(var item in json)
                    outputDto.Add(new CanteenHeatmapOutputDto(item));
                return new FcDto(0, "", JsonConvert.SerializeObject(outputDto));
            }
            return new FcDto(400, "没有这个校区的数据", null);

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}