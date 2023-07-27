using ChatSJTU.Plugin.Weather;
using System.Text;

namespace ChatSJTU.Plugin.Services
{
    public static class FunctionDef
    {
        public static string GetAllDef()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(WeatherController.GetDef());
            sb.Append(",");
            sb.Append(CanteenController.GetDef());
            sb.Append("]");
            return sb.ToString();
        }
    }
}
