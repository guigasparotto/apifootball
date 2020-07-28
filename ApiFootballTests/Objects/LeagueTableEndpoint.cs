using System;
using System.Linq;
using ApiFootballTests.Models.LeagueTable;
using ApiFootballTests.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiFootballTests.Models.Leagues;

namespace ApiFootballTests.Objects
{
    public class LeagueTableEndpoint : ApiClient
    {
        private readonly string _leagueTableEndpointUrl;
        public LeagueTableEndpoint()
        {
            _leagueTableEndpointUrl = $"{BaseAddress}/leagueTable";
        }

        public async Task<Standing> GetTeamByName(string teamName, int leagueId)
        {
            var leagueTable = await GetRequest<LeagueTable>($"{_leagueTableEndpointUrl}/{leagueId}");

            var standing = leagueTable.Api.Standings
                .First()
                .Find(s => s.TeamName == teamName);

            if (standing == null)
            {
                throw new Exception($"data not returned for standings {standing}");
            }
            return standing;
        }

        public async Task<Standing> GetBestCurrentForm(List<Standing> teams)
        {
            var bestTeam = new Standing();
            var bestForm = 0;

            foreach (var team in teams)
            {
                var leagueId = new LeagueEndpoint();
                
                League leagueResponse = new League();
                if (team.Group != null)
                {
                    leagueResponse = await leagueId.GetLeagueByName(team.Group);
                }
                var formScore = await GetTeamForm(team.TeamName, leagueResponse.LeagueId); 

                // It might be the case that two teams have the same score
                // Need to verify how to choose the best form in this case
                if (formScore <= bestForm) continue;
                bestForm = formScore;
                bestTeam = team;
            }

            return bestTeam;
        }

        public async Task<int> GetTeamForm(string teamName, int leagueId)
        {
            var standing =  await GetRequest<LeagueTable>($"{_leagueTableEndpointUrl}/{leagueId}");
            var currentForm = 0;

            foreach (char c in standing)
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
    }
}