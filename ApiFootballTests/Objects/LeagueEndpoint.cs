using ApiFootballTests.Base;
using ApiFootballTests.Models.Leagues;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFootballTests.Objects
{
    class LeagueEndpoint : ApiClient
    {
        private readonly string _leagueEndpointUrl;
        public LeagueEndpoint()
        {
            _leagueEndpointUrl = $"{BaseAddress}/leagues";
        }
        public async Task<League> GetLeagueById(int leagueId)
        {
            var league = await GetRequest<Leagues>(_leagueEndpointUrl);
            
            return league.Api.Leagues.First(x => x.LeagueId == leagueId);
        }

        public async Task<League> GetLeagueByName(string leagueName)
        {
            var league = await GetRequest<Leagues>(_leagueEndpointUrl);

            return league.Api.Leagues.First(x => x.Name == leagueName);
        }
    }
}
