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
    [Route("fc")]
    public class FuntionDefController : ControllerBase
    {

        private readonly ILogger<FuntionDefController> _logger;

        public FuntionDefController(ILogger<FuntionDefController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("def")]
        public string GetDef()
        {
            return FunctionDef.GetAllDef();
        }
    }
}