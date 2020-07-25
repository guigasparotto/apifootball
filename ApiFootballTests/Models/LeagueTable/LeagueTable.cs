using Newtonsoft.Json;

namespace ApiFootballTests.Models.LeagueTable
{
    public class LeagueTable
    {
        [JsonProperty("api", NullValueHandling = NullValueHandling.Ignore)]
        public Api Api { get; set; }
    }
}