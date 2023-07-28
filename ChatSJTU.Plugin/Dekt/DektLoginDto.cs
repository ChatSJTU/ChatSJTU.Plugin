using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Dekt
{
    public partial class DektLoginDto
    {
        [JsonProperty("client_id")]
        [System.Text.Json.Serialization.JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("code")]
        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("publicaccountid")]
        [System.Text.Json.Serialization.JsonPropertyName("publicaccountid")]
        public string PublicAccountId { get; set; }

        [JsonProperty("redirect_uri")]
        [System.Text.Json.Serialization.JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("scope")]
        [System.Text.Json.Serialization.JsonPropertyName("scope")]
        public string Scope { get; set; }
    }

    public partial class DektLoginResDto
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public DektLoginResDataDto Data { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

    public partial class DektLoginResDataDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jtoken")]
        public string Jtoken { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }
    }
}
