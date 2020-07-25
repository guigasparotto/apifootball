using System;
using System.Linq;
using ApiFootballTests.Models.LeagueTable;
using RestSharp;
using RestSharp.Serialization.Json;

namespace ApiFootballTests.Objects
{
    public class LeagueTableEndpoint : ApiClient
    {
        public LeagueTableEndpoint()
        {
            this._leagueTableEndpoint = $"{this.BaseAddress}/leagueTable";
        }

        public Standing? GetTeamByName(string teamName, int leagueId)
        {
            var leagueTable = this.GetLeagueTable(leagueId);

            var standing = leagueTable.Api.Standings
                .First()
                .Find(s => s.TeamName == teamName);

            return standing;
        }

        public LeagueTable GetLeagueTable(int leagueId)
        {
            var request = new RestRequest($"{this._leagueTableEndpoint}/{leagueId}", Method.GET);
            request.AddHeader("X-RapidAPI-Key", this.TestConfiguration.ApiKey);

            var httpResponse = RestClient.Execute(request);
            if (!httpResponse.IsSuccessful) throw new Exception(httpResponse.Content);
            
            var deserialize = new JsonDeserializer();
            
            return deserialize.Deserialize<LeagueTable>(httpResponse);
        }
        
        private readonly string _leagueTableEndpoint;
    }
}