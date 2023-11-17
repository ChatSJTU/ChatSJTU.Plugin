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
                            "description": "为模型提供获取 SJTU 校园生活数据的能力，如天气、食堂热力图等",
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
                            "description": "为模型提供获取“交我算”校级计算平台使用帮助、实时利用率的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get交我算())}}",
                            "functions": [
                                {{HpcOverviewController.GetDef()}}
                            ]
                        },
                        {
                            "id": "building",
                            "name": "SJTU 教学楼",
                            "description": "为模型提供获取教学楼信息的能力，如教学楼地图、教室排课情况、教室实时状态等",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get教学楼())}}",
                            "functions": [
                            ]
                        },
                        {
                            "id": "library",
                            "name": "SJTU 图书馆",
                            "description": "为模型提供获取图书馆信息的能力，如在馆人数、书籍查找、借用情况查询等",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get图书馆())}}",
                            "functions": [
                            ]
                        },
                        {
                            "id": "calendar",
                            "name": "我的日程",
                            "description": "为模型提供添加日程、查询日程的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get日程())}}",
                            "functions": [
                            ]
                        },
                        {
                            "id": "jiaowu",
                            "name": "教务信息",
                            "description": "为模型提供课程信息、成绩查询的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get教务())}}",
                            "functions": [
                            ]
                        },
                        {
                            "id": "caiwu",
                            "name": "财务信息",
                            "description": "为模型提供工资查询、学费查询的能力",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get财务())}}",
                            "functions": [
                            ]
                        },
                        {
                            "id": "space",
                            "name": "场馆预约",
                            "description": "为模型提供各类场馆预约的能力，包括小组自习室、面试空间、空教室等",
                            "icon": "data:image/svg+xml;base64,{{Convert.ToBase64String(EmbedResHelper.Get场馆预约())}}",
                            "functions": [
                            ]
                        }
                    ]
                }
                """;
            return json;
        }
    }
}
