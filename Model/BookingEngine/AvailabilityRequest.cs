using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class AvailabilityRequest
    {
        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("culture")]
        public string Culture { get; set; }

        [JsonPropertyName("checkIn")]
        public DateTime CheckIn { get; set; }

        [JsonPropertyName("checkOut")]
        public DateTime CheckOut { get; set; }

        [JsonPropertyName("occupancies")]
        public List<Occupancy> Occupancies { get; set; }

        [JsonPropertyName("multiPolygonalRegion")]
        public object MultiPolygonalRegion { get; set; }

        [JsonPropertyName("polygonalRegion")]
        public object PolygonalRegion { get; set; }

        [JsonPropertyName("hotelIds")]
        public List<string> HotelIds { get; set; }

        [JsonPropertyName("circularRegion")]
        public CircularRegion CircularRegion { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("countryOfResidence")]
        public string CountryOfResidence { get; set; }

        [JsonPropertyName("destinationCountryCode")]
        public string DestinationCountryCode { get; set; }

        public static async Task<AvailabilityRequest> GetBaseRequest(LocationResponse locationResponse)
        {
            var appSettings = TestContext.AppSettings;

            var request = new AvailabilityRequest
            {
                ChannelId = appSettings.ChannelId,
                CheckIn = DateTime.Now.AddMonths(3).AddDays(1),
                CheckOut = DateTime.Now.AddMonths(3).AddDays(2),
                CountryOfResidence = "IN",
                Culture = "en-US",
                Currency = appSettings.Currency,
                DestinationCountryCode = "GB",
                Nationality = "IN",
                Occupancies = new List<Occupancy>
                {
                    new()
                    {
                        NumOfAdults = 2,
                        ChildAges = new List<int>()
                    }
                },
                HotelIds = null,
                MultiPolygonalRegion = null,
                PolygonalRegion = null,
                CircularRegion = new CircularRegion
                {
                    CenterLat = locationResponse.Coordinates.Lat,
                    CenterLong = locationResponse.Coordinates.Long,
                    RadiusInKM = 20
                }
            };

            return await Task.FromResult(request);
        }

        public AvailabilityRequest AddCircularSearch(double lat, double lon)
        {
            CircularRegion = new CircularRegion
            {
                CenterLat = lat,
                CenterLong = lon,
                RadiusInKM = 20
            };
            return this;
        }

        public AvailabilityRequest AddOccupancy(List<Occupancy> occupancies)
        {
            Occupancies = new List<Occupancy>();
            Occupancies.AddRange(occupancies);            
            return this;
        }

        public AvailabilityRequest AddCheckin(DateTime checkIn)
        {
            CheckIn = checkIn;
            return this;
        }

        public AvailabilityRequest AddCheckout(DateTime checkOut)
        {
            CheckOut = checkOut;
            return this;
        }
    }

    public class CircularRegion
    {
        [JsonPropertyName("centerLat")]
        public double CenterLat { get; set; }

        [JsonPropertyName("centerLong")]
        public double CenterLong { get; set; }

        [JsonPropertyName("radiusInKM")]
        public int RadiusInKM { get; set; }
    }

    public class Occupancy
    {
        [JsonPropertyName("numOfAdults")]
        public int NumOfAdults { get; set; }

        [JsonPropertyName("childAges")]
        public List<int> ChildAges { get; set; }
    }

    public class RoomOccupancy
    {
        public Occupancy Occupancy { get; set; }

        public int RoomCount { get; set; }
    }
}
