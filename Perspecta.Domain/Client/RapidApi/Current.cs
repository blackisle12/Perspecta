using System.Text.Json.Serialization;

namespace Perspecta.Domain.Client.RapidApi
{
    public class Current
    {
        [JsonPropertyName("temp_c")]
        public decimal TempCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TempFahrenheit { get; set; }
    }
}
