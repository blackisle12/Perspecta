using System.Text.Json.Serialization;

namespace Perspecta.Domain.Client.RapidApi
{
    public class ForecastDayDay
    {
        [JsonPropertyName("maxtemp_c")]
        public decimal MaxTempCelsius { get; set; }

        [JsonPropertyName("maxtemp_f")]
        public decimal MaxTempFahrenheit { get; set; }

        [JsonPropertyName("mintemp_c")]
        public decimal MinTempCelsius { get; set; }

        [JsonPropertyName("mintemp_f")]
        public decimal MinTempFahrenheit { get; set; }

        [JsonPropertyName("avgtemp_c")]
        public decimal AvgTempCelsius { get; set; }

        [JsonPropertyName("avgtemp_f")]
        public decimal AvgTempFahrenheit { get; set; }
    }
}
