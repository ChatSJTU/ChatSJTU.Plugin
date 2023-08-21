using ChatSJTU.Plugin.BwcNews;
using ChatSJTU.Plugin.Canteen;
using ChatSJTU.Plugin.Dekt;
using ChatSJTU.Plugin.Helpers;
using ChatSJTU.Plugin.Models;
using ChatSJTU.Plugin.Services;
using ChatSJTU.Plugin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Teru.Code.Services;

namespace ChatSJTU.Plugin.Weather
{
    [ApiController]
    [Route("bwc")]
    public class BwcNewsController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<BwcNewsController> _logger;

        public BwcNewsController(ILogger<BwcNewsController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "bwc_news",
                    "description": "Get the latest articles from the Security Office（保卫处）, including the opening of the school gate, anti-fraud information, campus traffic management, etc.",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "PublishTime": {
                                "type": "string",
                                "description": "Publish time of the article"
                            },
                            "Title": {
                                "type": "string",
                                "description": "Title of the article"
                            },
                            "URL": {
                                "type": "string",
                                "description": "Link to the article's web page"
                            }
                        },
                        "required": []
                    }
                }
                """;
        }

        [HttpPost]
        [Route("news")]
        public FcDto GetNews()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            headers.Add("accept-encoding", "gzip, deflate, br");
            headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            headers.Add("cache-control", "max-age=0");
            headers.Add("sec-ch-ua", "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Microsoft Edge\";v=\"110\"");
            headers.Add("sec-ch-ua-mobile", "?0");
            headers.Add("sec-ch-ua-platform", "\"Linux\"");
            headers.Add("sec-fetch-dest", "document");
            headers.Add("sec-fetch-mode", "navigate");
            headers.Add("sec-fetch-site", "none");
            headers.Add("sec-fetch-user", "?1");
            headers.Add("upgrade-insecure-requests", "1");
            headers.Add("user-agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.0.0");

            var res = Web.Get("https://mp.weixin.qq.com/mp/appmsgalbum?__biz=MzA3MzMzMDIzNg==&action=getalbum&album_id=2034335777152614400&from_msgid=2649562310", headers);

            if (!res.success)
            {
                return new FcDto(400, "获取信息失败", "");
            }

            var reg0 = new Regex(@"articleList: \[(.+?)]", RegexOptions.Singleline);
            string arr = reg0.Match(res.result).Groups[1].Value;

            var reg1 = new Regex("title: '(.+?)',");
            var reg2 = new Regex("create_time: '(.+?)',");
            var reg3 = new Regex("url: '(.+?)',");

            var match1 = reg1.Matches(arr);
            var match2 = reg2.Matches(arr);
            var match3 = reg3.Matches(arr);

            if (match1.Count != match2.Count || match1.Count != match3.Count)
            {
                return new FcDto(400, "解析数据失败", "");
            }

            List<BwcNewsOutputDto> list = new List<BwcNewsOutputDto>();
            for (int i = 0; i < match1.Count; i++)
            {
                var t = new BwcNewsOutputDto()
                {
                    PublishTime = (int.Parse(match2[i].Groups[1].Value)).ToFriendlyTime(),
                    Title = match1[i].Groups[1].Value,
                    URL = match3[i].Groups[1].Value
                };
                list.Add(t);
            }

            return new FcDto(0, "", JsonConvert.SerializeObject(list));
        }
    }
}