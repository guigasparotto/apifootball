using System;
using Newtonsoft.Json;

namespace ApiFootballTests.Models.Leagues
{
    public class League
    {
        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("season", NullValueHandling = NullValueHandling.Ignore)]
        public int? Season { get; set; }

        [JsonProperty("season_start", NullValueHandling = NullValueHandling.Ignore)]
        public string SeasonStart { get; set; }

        [JsonProperty("season_end", NullValueHandling = NullValueHandling.Ignore)]
        public string SeasonEnd { get; set; }

        [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Logo { get; set; }

        [JsonProperty("flag")]
        public Uri Flag { get; set; }

        [JsonProperty("standings", NullValueHandling = NullValueHandling.Ignore)]
        public int? Standings { get; set; }

        [JsonProperty("is_current", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsCurrent { get; set; }

        [JsonProperty("coverage", NullValueHandling = NullValueHandling.Ignore)]
        public Coverage Coverage { get; set; }
    }
}
