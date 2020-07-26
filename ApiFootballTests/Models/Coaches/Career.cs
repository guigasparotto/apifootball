using Newtonsoft.Json;

namespace ApiFootballTests.Models.Coaches
{
    public class Career
    {
        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }
}
