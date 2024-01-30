using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class RoomsAndRatesRequest
    {
        [JsonPropertyName("searchSpecificProviders")]
        public bool SearchSpecificProviders { get; set; } = false;

        [JsonIgnore]
        public string HotelId { get; set; }

        [JsonIgnore]
        public string Token { get; set; }
    }
}
