using ApiFootballTests.Base;
using ApiFootballTests.Models.Coaches;
using System.Threading.Tasks;

namespace ApiFootballTests.Objects
{
    public class CoachsEndpoint : ApiClient
    {
        private readonly string _coachsEndpointUrl;
        public CoachsEndpoint()
        {
            _coachsEndpointUrl = $"{BaseAddress}/coachs";
        }

        public async Task<Coachs> GetCoachByName(string name)
        {
            string endpoint = $"{_coachsEndpointUrl}/search/{name}";
            
            var response = await GetRequest<Coachs>(endpoint);

            return response;
        }
    }
}
