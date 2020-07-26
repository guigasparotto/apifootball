using Dynamitey.DynamicObjects;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ApiFootballTests.Base
{
    public class ApiClient
    {
        public ApiClient()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            this.Settings = config.GetSection("ApiFootball").Get<Settings>();
            this.BaseAddress = $"{this.Settings.BaseUrl}/{this.Settings.ApiVersion}";
        }

        public void AuthoriseRequest()
        {
            this.RestRequest.AddHeader("X-RapidAPI-Key", this.Settings.ApiKey);
        }

        protected RestClient RestClient => new RestClient(BaseAddress);

        protected IRestRequest RestRequest { get; set; } = new RestRequest();   
        protected Settings Settings { get; }
        protected readonly string BaseAddress;
    }
}