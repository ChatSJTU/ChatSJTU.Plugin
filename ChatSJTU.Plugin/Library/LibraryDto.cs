using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Library
{
    public partial class LibraryDto
    {
        [JsonProperty("numbers")]
        public System.Collections.Generic.List<LibraryDetailDto> Numbers { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public partial class LibraryDetailDto
    {
        [JsonProperty("areaName")]
        public string AreaName { get; set; }

        [JsonProperty("inCounter")]
        public long InCounter { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }
}
