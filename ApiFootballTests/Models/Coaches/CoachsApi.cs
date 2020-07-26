using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiFootballTests.Models.Coaches
{
    public class CoachsApi
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long? Results { get; set; }

        [JsonProperty("coachs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Coach> Coachs { get; set; }
    }
}
