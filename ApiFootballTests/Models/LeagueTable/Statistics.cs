using Newtonsoft.Json;

namespace ApiFootballTests.Models.LeagueTable
{
    public class Statistics
    {
        [JsonProperty("matchsPlayed", NullValueHandling = NullValueHandling.Ignore)]
        public int? MatchsPlayed { get; set; }

        [JsonProperty("win", NullValueHandling = NullValueHandling.Ignore)]
        public int? Win { get; set; }

        [JsonProperty("draw", NullValueHandling = NullValueHandling.Ignore)]
        public int? Draw { get; set; }

        [JsonProperty("lose", NullValueHandling = NullValueHandling.Ignore)]
        public int? Lose { get; set; }

        [JsonProperty("goalsFor", NullValueHandling = NullValueHandling.Ignore)]
        public int? GoalsFor { get; set; }

        [JsonProperty("goalsAgainst", NullValueHandling = NullValueHandling.Ignore)]
        public int? GoalsAgainst { get; set; }
    }
}