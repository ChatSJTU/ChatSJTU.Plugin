using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Library
{
    public class LibraryOutputDto
    {
        public LibraryOutputDto(LibraryDetailDto item)
        {
            this.LibName = item.AreaName;
            this.InCounter = item.InCounter;
            this.Capacity = item.Max;
            this.rate = this.InCounter / this.Capacity;
            this.State = this.InCounter == 0 ? "闭馆中" : "正常开放";
        }

        [JsonProperty("libName")]
        public string LibName { get; set; }

        [JsonProperty("inCounter")]
        public long InCounter { get; set; }

        [JsonProperty("capacity")]
        public long Capacity { get; set; }

        [JsonProperty("occupancy_rate")]
        public double rate { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
