using Newtonsoft.Json;

namespace ChatSJTU.Plugin.BwcNews
{
    public class BwcNewsOutputDto
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("PublishTime")]
        public string PublishTime { get; set; }

        [JsonProperty("URL")]
        public string URL { get; set; }
    }
}
