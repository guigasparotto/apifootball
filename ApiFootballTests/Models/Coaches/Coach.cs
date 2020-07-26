using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiFootballTests.Models.Coaches
{
    public class Coach
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string Firstname { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastname { get; set; }

        [JsonProperty("age", NullValueHandling = NullValueHandling.Ignore)]
        public int? Age { get; set; }

        [JsonProperty("birth_date", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthDate { get; set; }

        [JsonProperty("birth_place", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthPlace { get; set; }

        [JsonProperty("birth_country", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthCountry { get; set; }

        [JsonProperty("nationality", NullValueHandling = NullValueHandling.Ignore)]
        public string Nationality { get; set; }

        [JsonProperty("height")]
        public object Height { get; set; }

        [JsonProperty("weight")]
        public object Weight { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }

        [JsonProperty("career", NullValueHandling = NullValueHandling.Ignore)]
        public List<Career> Career { get; set; }
    }
}
