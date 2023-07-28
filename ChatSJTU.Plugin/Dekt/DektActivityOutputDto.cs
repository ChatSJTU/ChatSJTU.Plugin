using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Dekt
{
    public class DektActivityOutputDto
    {
        [JsonProperty("activityEndTime")]
        public string ActiveEndTime { get; set; }

        [JsonProperty("activityStartTime")]
        public string ActiveStartTime { get; set; }

        [JsonProperty("Address")]
        public string ActivityAddress { get; set; }

        [JsonProperty("Category")]
        public string ActivityCategorya { get; set; }

        [JsonProperty("Code")]
        public string ActivityCode { get; set; }

        [JsonProperty("Description")]
        public string ActivityDesc { get; set; }

        [JsonProperty("Name")]
        public string ActivityName { get; set; }

        [JsonProperty("Status")]
        public string ActivityStatus { get; set; }

        [JsonProperty("ContactInfo")]
        public string ActivitySupport { get; set; }

        [JsonProperty("enrollEndTime")]
        public string EnrollEndTime { get; set; }

        [JsonProperty("enrollStartTime")]
        public string EnrollStartTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("recruitNumber")]
        public long RecruitQty { get; set; }

        [JsonProperty("visitCount")]
        public long VisitCount { get; set; }

        [JsonProperty("sponsor")]
        public string Sponsor { get; set; }

        [JsonProperty("webLink")]
        public string WebLink { get; set; }
    }
}
