using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiFootballTests.Models.Trophies
{
    public partial class TrophiesApi
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long? Results { get; set; }

        [JsonProperty("trophies", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trophy> Trophies { get; set; }
    }
}
