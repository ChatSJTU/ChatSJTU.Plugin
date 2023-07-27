using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ChatSJTU.Plugin.Models
{
    public class FcDto
    {
        public FcDto(int code, string message, string data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
