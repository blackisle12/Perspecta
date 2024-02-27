namespace Perspecta.Domain.Client.RapidApi
{
    public class ForecastResult
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }
}
