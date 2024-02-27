using Perspecta.Domain.Client.ApiNinja;

namespace Perspecta.Service.Interface
{
    public interface IApiNinjaService
    {
        Task<List<City>> GetCities(string country, int limit);
    }
}
