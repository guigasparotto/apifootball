using Newtonsoft.Json;

namespace ApiFootballTests.Models.Trophies
{
    public partial class Trophy
    {
        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public string League { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("season", NullValueHandling = NullValueHandling.Ignore)]
        public string Season { get; set; }

        [JsonProperty("place", NullValueHandling = NullValueHandling.Ignore)]
        public string Place { get; set; }
    }
}
