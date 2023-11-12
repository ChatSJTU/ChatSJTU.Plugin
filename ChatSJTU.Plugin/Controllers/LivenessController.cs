using ChatSJTU.Plugin.Canteen;
using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services;
using ChatSJTU.Plugin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("")]
    public class LivenessController : ControllerBase
    {

        private readonly ILogger<FuntionDefController> _logger;

        public LivenessController(ILogger<FuntionDefController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("liveness")]
        public string GetStatus()
        {
            return """
                {
                    "isAlive": true,
                    "message": "Ò»ÇÐÕý³£",
                }
                """;
        }
    }
}