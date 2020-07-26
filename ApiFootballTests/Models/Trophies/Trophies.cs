using Newtonsoft.Json;

namespace ApiFootballTests.Models.Trophies
{
    class Trophies
    {
        [JsonProperty("api", NullValueHandling = NullValueHandling.Ignore)]
        public TrophiesApi Api { get; set; }
    }
}
