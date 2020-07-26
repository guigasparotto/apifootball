using Newtonsoft.Json;

namespace ApiFootballTests.Models.Leagues
{
    public class Coverage
    {
        [JsonProperty("standings", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Standings { get; set; }

        [JsonProperty("fixtures", NullValueHandling = NullValueHandling.Ignore)]
        public Fixtures Fixtures { get; set; }

        [JsonProperty("players", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Players { get; set; }

        [JsonProperty("topScorers", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TopScorers { get; set; }

        [JsonProperty("predictions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Predictions { get; set; }

        [JsonProperty("odds", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Odds { get; set; }
    }
}
