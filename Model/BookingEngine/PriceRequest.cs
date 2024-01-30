using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class PriceRequest
    {
        [JsonIgnore]
        public string HotelId { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        [JsonIgnore]
        public string RecommendationId { get; set; }
    }
}
