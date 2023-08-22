﻿using ChatSJTU.Plugin.Weather;
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
                            "icon": "data:image/png;base64,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",
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
                            "icon": "data:image/png;base64,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",
                            "functions": [
                                {{DektController.GetDef()}},
                                {{BwcNewsController.GetDef()}}
                            ]
                        }
                    ]
                }
                """;
            return json;
        }
    }
}
