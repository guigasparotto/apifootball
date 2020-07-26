using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiFootballTests.Models.Leagues
{
    public class LeaguesApi
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public int? Results { get; set; }

        [JsonProperty("leagues", NullValueHandling = NullValueHandling.Ignore)]
        public List<League> Leagues { get; set; }
    }
}
