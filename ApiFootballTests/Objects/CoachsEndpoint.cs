using ApiFootballTests.Base;
using ApiFootballTests.Models.Coaches;
using RestSharp;
using System;

namespace ApiFootballTests.Objects
{
    public class CoachsEndpoint : ApiClient
    {
        public CoachsEndpoint()
        {
            _coachsEndpointUrl = $"{BaseAddress}/coachs";
        }

        public Coachs GetCoachByName(string name)
        {
            this.RestRequest = new RestRequest($"{this._coachsEndpointUrl}/search/{name}", Method.GET);
            this.AuthoriseRequest();

            var httpResponse = this.RestClient
                .ExecuteGetAsync<Coachs>(this.RestRequest)
                .GetAwaiter()
                .GetResult();

            if (!httpResponse.IsSuccessful) throw new Exception(httpResponse.Content);

            return httpResponse.Data;
        }

        private readonly string _coachsEndpointUrl;
    }
}
