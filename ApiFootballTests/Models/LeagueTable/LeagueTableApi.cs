using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiFootballTests.Models.LeagueTable
{
    public class LeagueTableApi
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public int? Results { get; set; }

        [JsonProperty("standings", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<Standing>> Standings { get; set; }
    }
}