using Microsoft.Extensions.Options;
using Perspecta.Domain.Client.RapidApi;
using Perspecta.Domain.Configurations;
using Perspecta.Service.Interface;
using RestSharp;

namespace Perspecta.Service
{
    public class RapidApiService : IRapidApiService
    {
        private readonly RapidApiSettings _settings;
        private readonly RestClient _restClient;

        public RapidApiService(IOptions<RapidApiSettings> setings)
        {
            _settings = setings.Value;

            _restClient = new RestClient(
                new RestClientOptions(_settings.ApiUrl));

            _restClient.AddDefaultHeader("X-RapidAPI-Key", _settings.ApiKey);
            _restClient.AddDefaultHeader("X-RapidAPI-Host", _settings.ApiHost);
        }

        public async Task<ForecastResult> GetWeatherForecast(string city, int days)
        {
            var request = new RestRequest(_settings.ForecastUrl)
                .AddParameter("q", city)
                .AddParameter(nameof(days), days);

            var forecastResult = await _restClient.GetAsync<ForecastResult>(request);

            return forecastResult!;
        }
    }
}
