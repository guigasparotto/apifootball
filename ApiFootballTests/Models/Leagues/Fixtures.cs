using Newtonsoft.Json;

namespace ApiFootballTests.Models.Leagues
{
    public class Fixtures
    {
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Events { get; set; }

        [JsonProperty("lineups", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lineups { get; set; }

        [JsonProperty("statistics", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Statistics { get; set; }

        [JsonProperty("players_statistics", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PlayersStatistics { get; set; }
    }
}
