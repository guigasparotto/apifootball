using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ApiFootballTests.Base
{
    public class ApiClient
    {
        protected RestClient RestClient => new RestClient(BaseAddress);
        protected IRestRequest RestRequest { get; set; } = new RestRequest();
        private Settings Settings { get; }
        
        protected readonly string BaseAddress;

        protected ApiClient()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            Settings = config.GetSection("ApiFootball").Get<Settings>();
            BaseAddress = $"{Settings.BaseUrl}/{Settings.ApiVersion}";
        }

        private void AuthoriseRequest()
        {
            if(string.IsNullOrEmpty(Settings.ApiKey))
            {
                throw new Exception("API Key is null in the json file.");
            }
            RestRequest.AddHeader("X-RapidAPI-Key", Settings.ApiKey);
            RestRequest.AddHeader("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
        }
  
        public async Task<T> GetRequest<T>(string endpoint)
        {
            RestRequest = new RestRequest($"{endpoint}", Method.GET);
            
            AuthoriseRequest();

            IRestResponse<T> httpResponse;
            try
            {
                httpResponse = await RestClient.ExecuteGetAsync<T>(RestRequest);
                
                if (!httpResponse.IsSuccessful) 
                    throw new Exception(httpResponse.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return httpResponse.Data;
        }
    }
}