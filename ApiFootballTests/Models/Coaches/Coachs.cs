using Newtonsoft.Json;

namespace ApiFootballTests.Models.Coaches
{
    public class Coachs
    {
        [JsonProperty("api", NullValueHandling = NullValueHandling.Ignore)]
        public CoachsApi Api { get; set; }
    }
}
