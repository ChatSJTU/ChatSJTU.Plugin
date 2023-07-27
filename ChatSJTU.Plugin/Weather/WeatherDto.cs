using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Weather
{
    public partial class WeatherDto
    {
        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("daily")]
        public System.Collections.Generic.List<Daily> Daily { get; set; }

        [JsonProperty("hourly")]
        public System.Collections.Generic.List<Hourly> Hourly { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("minutely")]
        public System.Collections.Generic.List<Minutely> Minutely { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public long TimezoneOffset { get; set; }
    }

    public partial class Current
    {
        [JsonProperty("clouds")]
        public double Clouds { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("sunrise")]
        public double Sunrise { get; set; }

        [JsonProperty("sunset")]
        public double Sunset { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("weather")]
        public System.Collections.Generic.List<CurrentWeather> Weather { get; set; }

        [JsonProperty("wind_deg")]
        public double WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }

    public partial class CurrentWeather
    {
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        public string Main { get; set; }
    }

    public partial class Daily
    {
        [JsonProperty("clouds")]
        public double Clouds { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("moonrise")]
        public double Moonrise { get; set; }

        [JsonProperty("moonset")]
        public double Moonset { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }

        [JsonProperty("sunrise")]
        public double Sunrise { get; set; }

        [JsonProperty("sunset")]
        public double Sunset { get; set; }

        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }

        [JsonProperty("weather")]
        public System.Collections.Generic.List<DailyWeather> Weather { get; set; }

        [JsonProperty("wind_deg")]
        public double WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }

    public partial class FeelsLike
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }
    }

    public partial class Temp
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }
    }

    public partial class DailyWeather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }
    }

    public partial class Hourly
    {
        [JsonProperty("clouds")]
        public double Clouds { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("weather")]
        public System.Collections.Generic.List<HourlyWeather> Weather { get; set; }

        [JsonProperty("wind_deg")]
        public double WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }

    public partial class HourlyWeather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }
    }

    public partial class Minutely
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("precipitation")]
        public double Precipitation { get; set; }
    }
}
