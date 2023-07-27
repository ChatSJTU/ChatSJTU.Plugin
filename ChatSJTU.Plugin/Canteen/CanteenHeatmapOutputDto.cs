using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Canteen
{
    public partial class CanteenHeatmapOutputDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("occupancy_rate")]
        public double rate { get; set; }

        [JsonProperty("taken_seat")]
        public long SeatU { get; set; }

        [JsonProperty("total_seat")]
        public long SeatS { get; set; }

        public CanteenHeatmapOutputDto(CanteenHeatmapDto dto)
        {
            this.SeatS = dto.SeatS;
            this.SeatU = dto.SeatU;
            this.Name = dto.Name;
            this.rate = (dto.SeatS == 0) ? 0 : (dto.SeatU / dto.SeatS);
        }
    }
}
