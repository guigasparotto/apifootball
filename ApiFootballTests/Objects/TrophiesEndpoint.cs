using ApiFootballTests.Base;
using ApiFootballTests.Models.Trophies;
using RestSharp;
using System;

namespace ApiFootballTests.Objects
{
    class TrophiesEndpoint : ApiClient
    {
        public TrophiesEndpoint()
        {
            this._trophiesEndpointUrl = $"{this.BaseAddress}/trophies";
        }

        public Trophies GetTrophiesByCoachId(int coachId)
        {
            this.RestRequest = new RestRequest($"{this._trophiesEndpointUrl}/coach/{coachId}", Method.GET);
            this.AuthoriseRequest();

            var httpResponse = this.RestClient
                .ExecuteGetAsync<Trophies>(this.RestRequest)
                .GetAwaiter()
                .GetResult();

            if (!httpResponse.IsSuccessful) throw new Exception(httpResponse.Content);

            return httpResponse.Data;
        }

        private readonly string _trophiesEndpointUrl;
    }
}
