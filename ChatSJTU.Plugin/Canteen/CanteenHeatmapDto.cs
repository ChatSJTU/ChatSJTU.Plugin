using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Canteen
{
    public partial class CanteenHeatmapDto
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Px")]
        public long Px { get; set; }

        [JsonProperty("Seat_r")]
        public long SeatR { get; set; }

        [JsonProperty("Seat_s")]
        public long SeatS { get; set; }

        [JsonProperty("Seat_u")]
        public long SeatU { get; set; }
    }
}
