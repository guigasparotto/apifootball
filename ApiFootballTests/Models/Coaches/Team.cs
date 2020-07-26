using Newtonsoft.Json;

namespace ApiFootballTests.Models.Coaches
{
    public class Team
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
