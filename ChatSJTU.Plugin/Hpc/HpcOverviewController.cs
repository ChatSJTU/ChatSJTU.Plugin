using ChatSJTU.Plugin.Library;
using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services.Contracts;
using ChatSJTU.Plugin.Weather;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Hpc
{
    [ApiController]
    [Route("hpc")]
    public class HpcOverviewController : ControllerBase, IFunctionCalling
    {
        private readonly ILogger<HpcOverviewController> _logger;

        public HpcOverviewController(ILogger<HpcOverviewController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "hpc_overview",
                    "description": "Get high performance computing system status (real time utilization)",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "Sy": {
                                "type": "string",
                                "description": "思源一号实时利用率（已用核数 / 总核数）"
                            },
                            "SyPercent": {
                                "type": "string",
                                "description": "思源一号实时利用率百分比"
                            },
                            "Pi": {
                                "type": "string",
                                "description": "π2.0集群实时利用率（已用核数 / 总核数）"
                            },
                            "PiPercent": {
                                "type": "string",
                                "description": "π2.0集群实时利用率百分比"
                            },
                            "Gpu": {
                                "type": "string",
                                "description": "AI平台实时利用率（已用核数 / 总核数）"
                            },
                            "GpuPercent": {
                                "type": "string",
                                "description": "AI平台实时利用率百分比"
                            },
                            "Arm": {
                                "type": "string",
                                "description": "ARM平台实时利用率（已用核数 / 总核数）"
                            },
                            "ArmPercent": {
                                "type": "string",
                                "description": "ARM平台实时利用率百分比"
                            },
                            "Storage": {
                                "type": "string",
                                "description": "存储系统实时利用率（已用容量 / 总容量）"
                            },
                            "StoragePercent": {
                                "type": "string",
                                "description": "存储系统实时利用率百分比"
                            }
                        },
                        "required": []
                    }
                }
                """;
        }

        [HttpPost]
        [Route("overview")]
        public FcDto GetOverview()
        {
            //Debug.WriteLine(argv.location);
            var res = Web.Get("https://account.hpc.sjtu.edu.cn/billing/monitor/now", new Dictionary<string, string>());
            if (res.success)
            {
                var json = JsonConvert.DeserializeObject<HpcOverviewDto>(res.result);

                return new FcDto(0, "", JsonConvert.SerializeObject(new HpcOverviewOutputDto(json)));
            }
            return new FcDto(400, $"{res.message}", null);
        }
    }
}
