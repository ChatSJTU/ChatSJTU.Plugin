using ChatSJTU.Plugin.Canteen;
using ChatSJTU.Plugin.Dekt;
using ChatSJTU.Plugin.Helpers;
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
    [Route("dekt")]
    public class DektController : ControllerBase, IFunctionCalling
    {

        private readonly ILogger<DektController> _logger;

        public DektController(ILogger<DektController> logger)
        {
            _logger = logger;
        }

        public static string GetDef()
        {
            return """
                {
                    "name": "dekt_NewestActivityList",
                    "description": "Get the newest activities in “the second class”（第二课堂）. When returning the result, please wrap every activity in HTML format <details> <summary>{Title}</summary>{Content}</details>",
                    "parameters": {
                        "type": "object",
                        "properties": {
                            "activityEndTime": {
                                "type": "string",
                                "description": "Ending time of the activity"
                            },
                            "activityStartTime": {
                                "type": "string",
                                "description": "Beginning time of the activity"
                            },
                            "enrollEndTime": {
                                "type": "string",
                                "description": "Ending time of enrollment"
                            },
                            "enrollStartTime": {
                                "type": "string",
                                "description": "Beginning time of enrollment"
                            },
                            "Address": {
                                "type": "string",
                                "description": "Activity location"
                            },
                            "Category": {
                                "type": "string",
                                "description": "Category of the activity"
                            },
                            "Code": {
                                "type": "string",
                                "description": "Internal ID"
                            },
                            "id": {
                                "type": "string",
                                "description": "Internal ID"
                            },
                            "Description": {
                                "type": "string",
                                "description": "Introduction of the activity"
                            },
                            "Name": {
                                "type": "string",
                                "description": "Name of the activity"
                            },
                            "Status": {
                                "type": "string",
                                "description": "Enrollment status of the activity"
                            },
                            "ContactInfo": {
                                "type": "string",
                                "description": "Contact info of the activity"
                            },
                            "recruitNumber": {
                                "type": "string",
                                "description": "Number of people recruited to the event"
                            },
                            "visitCount": {
                                "type": "string",
                                "description": "Number of visitors to the activity page"
                            },
                            "sponsor": {
                                "type": "string",
                                "description": "Event organizer"
                            },
                            "webLink": {
                                "type": "string",
                                "description": "Link to the activity's web page, enter the web page to sign up for the activity"
                            }
                        },
                        "required": []
                    }
                }
                """;
        }

        [HttpPost]
        [Route("NewestActivityList")]
        public FcDto GetNewestActivity()
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = true, CookieContainer = GlobalCookie.CookieContainer, UseCookies = true, MaxAutomaticRedirections = 100 });

            var res = client.GetAsync("https://jaccount.sjtu.edu.cn/oauth2/authorize?response_type=code&client_id=sowyD3hGhP6f6O92bevg&redirect_uri=https://dekt.sjtu.edu.cn/h5/index&state=&scope=basic").Result;

            if (res.RequestMessage.RequestUri.OriginalString.Contains("jaccount"))
            {
                return new FcDto(400, "dekt认证失败（jaccount）", "");
            }

            DektLoginDto loginDto = new DektLoginDto();
            loginDto.Code = res.RequestMessage.RequestUri.Query.Split('=').Last();
            loginDto.RedirectUri = "https://dekt.sjtu.edu.cn/h5/index";
            loginDto.Scope = "basic";
            loginDto.PublicAccountId = "sjtuvirtual";
            loginDto.ClientId = "sowyD3hGhP6f6O92bevg";

            var req2 = new HttpRequestMessage(HttpMethod.Post, $"https://dekt.sjtu.edu.cn/api/auth/secondclass/loginByJa?time={TimeHelper.GetTimeStampMilli()}&publicaccountid=sjtuvirtual");
            req2.Headers.Add("jtoken", new string[] { "null" });
            req2.Headers.Add("curUserId", new string[] { "null" });
            req2.Headers.Add("publicaccountid", new string[] { "sjtuvirtual" });
            req2.Headers.Add("tenantId", new string[] { "null" });
            req2.Headers.Add("token", new string[] { "null" });

            req2.Content = JsonContent.Create(loginDto);

            var res2 = client.Send(req2);

            if (!res2.IsSuccessStatusCode)
            {
                return new FcDto(400, "dekt认证失败（loginByJa）", "");
            }

            var json2 = res2.Content.ReadFromJsonAsync<DektLoginResDto>().GetAwaiter().GetResult();
            if (json2.Code != 0)
            {
                return new FcDto(400, $"dekt认证失败（{json2.Msg}）", "");
            }

            var token = json2.Data.Token;
            var jtoken = json2.Data.Jtoken;

            var req3 = new HttpRequestMessage(HttpMethod.Post, $"https://dekt.sjtu.edu.cn/api/wmt/secondclass/fmGetNewestActivityList?tenantId=500&token={token}");
            req3.Headers.Add("Jtoken", new string[] { jtoken });
            req3.Headers.Add("Curuserid", new string[] { "1700009978" });

            var res3 = client.Send(req3);

            if (!res3.IsSuccessStatusCode)
            {
                return new FcDto(400, "dekt获取数据失败（fmGetNewestActivityList）", "");
            }

            var json3 = res3.Content.ReadFromJsonAsync<DektActivityDto>().GetAwaiter().GetResult();
            if (json3.Code != 0)
            {
                return new FcDto(400, $"dekt获取数据失败（{json3.Msg}）", "");
            }

            List<DektActivityOutputDto> list = new List<DektActivityOutputDto>();
            foreach(var item in json3.Data)
            {
                var t = new DektActivityOutputDto()
                {
                    RecruitQty = item.RecruitQty,
                    ActivityAddress = item.ActivityAddress,
                    ActivityCode = item.ActivityCode,
                    ActivityDesc = item.ActivityDesc,
                    ActivityName = item.ActivityName,
                    Id = item.Id,
                    Sponsor = item.Sponsor,
                    VisitCount = item.VisitCount,
                    ActiveEndTime = item.ActiveEndTime.ToFriendlyTime(),
                    ActiveStartTime = item.ActiveStartTime.ToFriendlyTime(),
                    EnrollEndTime = item.EnrollEndTime.ToFriendlyTime(),
                    EnrollStartTime = item.EnrollStartTime.ToFriendlyTime()
                };
                t.ActivityCategorya = item.ActivityCategorya switch
                {
                    "hszl"=>"红色之旅",
                    "ldjy"=>"劳动教育",
                    "zygy"=>"志愿公益",
                    "wthd"=>"文体活动",
                    "kjcx"=>"科技创新",
                    "jtjz"=>"讲坛讲座",
                    "qt"=>"其他",
                    _=>"未知",
                };
                t.ActivitySupport = item.ActivitySupport
                    .Select(s => $"{s.ContactName}，{s.ContactInfo}")
                    .Aggregate((s1, s2) => $"{s1}; {s2}");
                var time = TimeHelper.GetTimeStampMilliInt64();
                t.ActivityStatus = (time < item.EnrollStartTime) ? "报名未开始" :
                    ((time > item.EnrollEndTime) ? "报名已结束" : "报名进行中");

                var contentinfo = JsonConvert.DeserializeObject<ActivityContentInfoDto>(item.ActivityContentInfo);

                t.WebLink = $"https://dekt.sjtu.edu.cn/h5/microPage?id={contentinfo.Template.Id}&activityCode={item.ActivityCode}";
                list.Add(t);
            }

            return new FcDto(0, "", JsonConvert.SerializeObject(list));
        }
    }
}