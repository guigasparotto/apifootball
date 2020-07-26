using ApiFootballTests.Base;
using ApiFootballTests.Models.Leagues;
using RestSharp;
using System;
using System.Linq;

namespace ApiFootballTests.Objects
{
    class LeagueEndpoint : ApiClient
    {
        public LeagueEndpoint()
        {
            this._leagueEndpointUrl = $"{this.BaseAddress}/leagues";
        }

        public League GetLeagueById(int leagueId)
        {
            var league = this.GetLeagues().Api.Leagues.First(x => x.LeagueId == leagueId);

            return league;
        }

        public League GetLeagueByName(string leagueName)
        {
            var league = this.GetLeagues().Api.Leagues.First(x => x.Name == leagueName);

            return league;
        }

        public Leagues GetLeagues()
        {
            this.RestRequest = new RestRequest($"{this._leagueEndpointUrl}", Method.GET);
            this.AuthoriseRequest();

            var httpResponse = this.RestClient
                .ExecuteGetAsync<Leagues>(this.RestRequest)
                .GetAwaiter()
                .GetResult();

            if (!httpResponse.IsSuccessful) throw new Exception(httpResponse.Content);

            return httpResponse.Data;
        }

        private readonly string _leagueEndpointUrl;
    }
}
