using System;
using Newtonsoft.Json;

namespace ApiFootballTests.Models.LeagueTable
{
    public class Standing
    {
        [JsonProperty("rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rank { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? TeamId { get; set; }

        [JsonProperty("teamName", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamName { get; set; }

        [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Logo { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string? Group { get; set; }

        [JsonProperty("forme", NullValueHandling = NullValueHandling.Ignore)]
        public string Forme { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public object? Status { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("all", NullValueHandling = NullValueHandling.Ignore)]
        public Statistics Statistics { get; set; }

        [JsonProperty("home", NullValueHandling = NullValueHandling.Ignore)]
        public Statistics Home { get; set; }

        [JsonProperty("away", NullValueHandling = NullValueHandling.Ignore)]
        public Statistics Away { get; set; }

        [JsonProperty("goalsDiff", NullValueHandling = NullValueHandling.Ignore)]
        public int? GoalsDiff { get; set; }

        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; set; }

        [JsonProperty("lastUpdate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdate { get; set; }
    }
}