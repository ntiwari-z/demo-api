using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class BookResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("bookingStatus")]
        public string BookingStatus { get; set; }

        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; }

        [JsonPropertyName("providerConfirmationNumber")]
        public string ProviderConfirmationNumber { get; set; }

        [JsonPropertyName("hotelConfirmationNumber")]
        public string HotelConfirmationNumber { get; set; }

        [JsonPropertyName("cancellationToken")]
        public string CancellationToken { get; set; }

        [JsonPropertyName("roomConfirmation")]
        public List<RoomConfirmationInfo> RoomConfirmationDetails { get; set; }

        [JsonPropertyName("Error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }

    public class RoomConfirmationInfo
    {
        [JsonPropertyName("rateId")]
        public string RateId { get; set; }

        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("providerConfirmationNumber")]
        public string ProviderConfirmationNumber { get; set; }

        [JsonPropertyName("hotelConfirmationNumber")]
        public string HotelConfirmationNumber { get; set; }

        [JsonPropertyName("hotelCancellationNumber")]
        public string HotelCancellationNumber { get; set; }

        [JsonPropertyName("providerCancellationNumber")]
        public string ProviderCancellationNumber { get; set; }

        [JsonPropertyName("cancellationToken")]
        public string CancellationToken { get; set; }

        [JsonPropertyName("bookingStatus")]
        public string BookingStatus { get; set; }
    }
}
