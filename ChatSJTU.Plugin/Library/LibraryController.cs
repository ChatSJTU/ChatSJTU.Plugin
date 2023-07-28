using ChatSJTU.Plugin.Canteen;
using ChatSJTU.Plugin.Library;
using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("library")]
    public class LibraryController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "library_heatmap",
                    "description": "Get library seat occupancy information",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "libName": {
                                "type": "string",
                                "description": "The name of library"
                            },
                            "inCounter": {
                                "type": "number",
                                "description": "The number of people in the library"
                            },
                            "capacity": {
                                "type": "number",
                                "description": "Capacity of the library"
                            },
                            "occupancy_rate": {
                                "type": "number",
                                "description": "The occupancy rate of the library"
                            },
                            "state": {
                                "type": "string",
                                "description": "Current state of the library"
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
            var res = Web.Get("https://zgrstj.lib.sjtu.edu.cn/cp", new Dictionary<string, string>());
            if (res.success)
            {
                var jsonstr = res.result.Replace("CountPerson(", "").Replace(");", "");
                var json = JsonConvert.DeserializeObject<LibraryDto>(jsonstr);

                List<LibraryOutputDto> outputDto = new List<LibraryOutputDto>();
                foreach(var item in json.Numbers)
                    outputDto.Add(new LibraryOutputDto(item));
                return new FcDto(0, "", JsonConvert.SerializeObject(outputDto));
            }
            return new FcDto(400, $"{res.message}", null);
        }
    }
}