using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services.Contracts;
using DDGS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("web")]
    public class WebSearchController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<WebSearchController> _logger;

        public WebSearchController(ILogger<WebSearchController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "web_search",
                    "description": "查询搜索引擎获取互联网信息",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "keywords": {
                                "type": "string",
                                "description": "搜索的文本内容"
                            }
                        },
                        "required": ["keywords"]
                    }
                }
                """;
        }

        [HttpPost]
        [Route("search")]
        public FcDto Post([FromBody] WebSearchInputDto argv)
        {
            Debug.WriteLine(argv.keywords);
            _logger.LogInformation(argv.keywords);
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler() { Proxy = new WebProxy("http://127.0.0.1:17890") }) { Timeout = new TimeSpan(0, 0, 10) };
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json, text/javascript, */*; q=0.01");
                client.DefaultRequestHeaders.Referrer = new Uri("https://duckduckgo.com/");
                DDGS.DDGS ddg = new DDGS.DDGS(client);
                var res = ddg.Text(argv.keywords);
                if (res == null || res.Count == 0)
                    throw new Exception();
                return new FcDto(0, "", JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new FcDto(400, "搜索时发生错误。", null);
            }
        }
    }
}