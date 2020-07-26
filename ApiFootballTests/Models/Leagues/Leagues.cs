using Newtonsoft.Json;

namespace ApiFootballTests.Models.Leagues
{
    public class Leagues
    {
        [JsonProperty("api", NullValueHandling = NullValueHandling.Ignore)]
        public LeaguesApi Api { get; set; }
    }
}
