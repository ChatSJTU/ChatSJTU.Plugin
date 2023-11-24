using ChatSJTU.Plugin.Helpers;
using ChatSJTU.Plugin.Hpc;
using ChatSJTU.Plugin.Weather;
using System.Text;

namespace ChatSJTU.Plugin.Services
{
    public static class FunctionDef
    {
        public static string GetAllDef()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append()
            //sb.Append("[");
            //sb.Append(WeatherController.GetDef());
            //sb.Append(",");
            //sb.Append(CanteenController.GetDef());
            //sb.Append(",");
            //sb.Append(DektController.GetDef());
            //sb.Append(",");
            //sb.Append(LibraryController.GetDef());
            //sb.Append(",");
            //sb.Append(BwcNewsController.GetDef());
            //sb.Append("]");
            var json = $$"""
                {
                    "code": 200,
                    "message": "success",
                    "data": [
                        {
                            "id": "campus",
                            "name": "SJTU 校园生活",
                            "description": "为模型提供获取 SJTU 校园生活数据的能力，如天气、食堂热力图、图书馆上座率等",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get交大生活())}}",
                            "functions": [
                                {{WeatherController.GetDef()}},
                                {{CanteenController.GetDef()}},
                                {{LibraryController.GetDef()}}
                            ]
                        },
                        {
                            "id": "service",
                            "name": "SJTU 信息服务",
                            "description": "为模型提供访问校内常用网站信息服务的能力，如第二课堂活动查询、保卫处新闻等",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get校园管理())}}",
                            "functions": [
                                {{DektController.GetDef()}},
                                {{BwcNewsController.GetDef()}}
                            ]
                        },
                        {
                            "id": "hpc",
                            "name": "SJTU 超算平台",
                            "description": "为模型提供获取超算平台使用帮助、实时利用率的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get交我算())}}",
                            "functions": [
                                {{HpcOverviewController.GetDef()}}
                            ]
                        },
                        {
                            "id": "web",
                            "name": "搜索引擎",
                            "description": "为模型提供获取搜索互联网以获取最新信息的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.GetGlobe())}}",
                            "functions": [
                                {{WebSearchController.GetDef()}}
                            ]
                        }
                    ]
                }
                """;
            return json;
        }
    }
}
