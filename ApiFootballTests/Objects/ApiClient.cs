using ApiFootballTests.Helpers;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ApiFootballTests.Objects
{
    public class ApiClient
    {
        public ApiClient()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            this.TestConfiguration = config.GetSection("ApiFootball").Get<TestConfiguration>();
            this.BaseAddress = $"{this.TestConfiguration.BaseUrl}/{this.TestConfiguration.ApiVersion}";
        }

        protected RestClient RestClient => new RestClient(BaseAddress);
        
        protected TestConfiguration TestConfiguration { get; }
        protected readonly string BaseAddress;
    }
}