using Perspecta.Domain.Client.RapidApi;

namespace Perspecta.Service.Interface
{
    public interface IRapidApiService
    {
        Task<ForecastResult> GetWeatherForecast(string city, int days);
    }
}
