using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class PriceResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("hotel")]
        public HotelPrice Hotel { get; set; }

        [JsonPropertyName("rmRequestJson")]
        public RmRequestJson RmRequestJson { get; set; }
    }

    public class HotelPrice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }

        [JsonPropertyName("rates")]
        public List<RateRR> Rates { get; set; }

        [JsonPropertyName("rateToCompare")]
        public RateRR RateToCompare { get; set; }
    }
}
