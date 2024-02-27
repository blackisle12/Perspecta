using Microsoft.Extensions.Options;
using Perspecta.Domain.Client.ApiNinja;
using Perspecta.Domain.Configurations;
using Perspecta.Service.Interface;
using RestSharp;

namespace Perspecta.Service
{
    public class ApiNinjaService : IApiNinjaService
    {
        private readonly ApiNinjaSettings _settings;
        private readonly RestClient _restClient;

        public ApiNinjaService(IOptions<ApiNinjaSettings> settings)
        {
            _settings = settings.Value;

            _restClient = new RestClient(
                new RestClientOptions(_settings.ApiUrl));

            _restClient.AddDefaultHeader("X-Api-Key", _settings.ApiKey);
        }

        public async Task<List<City>> GetCities(string country, int limit)
        {
            var request = new RestRequest(_settings.CityUrl)
                .AddParameter(nameof(country), country)
                .AddParameter(nameof(limit), limit);

            var cities = await _restClient.GetAsync<List<City>>(request);

            return cities!.OrderByDescending(c => c.Population).ToList();
        }
    }
}