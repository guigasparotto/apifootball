using System;
using System.Linq;
using ApiFootballTests.Models.LeagueTable;
using ApiFootballTests.Base;
using RestSharp;
using System.Collections.Generic;

namespace ApiFootballTests.Objects
{
    public class LeagueTableEndpoint : ApiClient
    {
        public LeagueTableEndpoint()
        {
            this._leagueTableEndpointUrl = $"{this.BaseAddress}/leagueTable";
        }

        public Standing GetTeamByName(string teamName, int leagueId)
        {
            var leagueTable = this.GetLeagueTable(leagueId);

            var standing = leagueTable.Api.Standings
                .First()
                .Find(s => s.TeamName == teamName);

            return standing;
        }

        public Standing GetBestCurrentForm(List<Standing> teams)
        {
            var bestTeam = new Standing();
            var bestForm = 0;

            foreach (var team in teams)
            {
                var leagueId = new LeagueEndpoint().GetLeagueByName(team.Group).LeagueId;

                var formScore = this.GetTeamForm(team.TeamName, leagueId); 

                // It might be the case that two teams have the same score
                // Need to verify how to choose the best form in this case
                if (formScore > bestForm)
                {
                    bestForm = formScore;
                    bestTeam = team;
                }
            }

            return bestTeam;
        }

        public int GetTeamForm(string teamName, int leagueId)
        {
            var standing = this.GetTeamByName(teamName, leagueId);
            var currentForm = 0;

            foreach (char c in standing.Forme)
            {
                switch(c)
                {
                    case 'W':
                        currentForm += 3;
                        break;
                    case 'D':
                        currentForm += 1;
                        break;
                    case 'L':
                        currentForm += 0;
                        break;
                    default:
                        break;
                }
            }

            return currentForm;
        }

        public LeagueTable GetLeagueTable(int leagueId)
        {
            this.RestRequest = new RestRequest($"{this._leagueTableEndpointUrl}/{leagueId}", Method.GET);
            this.AuthoriseRequest();

            var httpResponse = this.RestClient
                .ExecuteGetAsync<LeagueTable>(this.RestRequest)
                .GetAwaiter()
                .GetResult();

            if (!httpResponse.IsSuccessful) throw new Exception(httpResponse.Content);

            return httpResponse.Data;
        }
        
        private readonly string _leagueTableEndpointUrl;
    }
}