using ApiFootballTests.Base;
using ApiFootballTests.Models.Trophies;
using System.Threading.Tasks;

namespace ApiFootballTests.Objects
{
    class TrophiesEndpoint : ApiClient
    {
        private readonly string _trophiesEndpointUrl;
        public TrophiesEndpoint()
        {
            _trophiesEndpointUrl = $"{BaseAddress}/trophies";
        }
        public async Task<Trophies> GetTrophiesByCoachId(int coachId)
        {
            string endpoint = $"{_trophiesEndpointUrl}/coach/{coachId}";
            var response = await GetRequest<Trophies>(endpoint);

            return response;
        }
    }
}
