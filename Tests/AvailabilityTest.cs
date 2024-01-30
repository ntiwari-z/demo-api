using Allure.Xunit.Attributes;
using Model.BookingEngine;
using Utility.Pipeline.Availability;
using Utility.Pipeline.Book;
using Utility.Pipeline.Core;
using Utility.Pipeline.Location;
using Utility.Pipeline.Price;
using Utility.Pipeline.RoomsAndRates;
using Utility.Pipeline.Search;
using Utility.WebClient;

namespace Tests
{
    public class AvailabilityTest : BaseTest
    {
        public AvailabilityTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> SearchData =>
        new List<object[]>
        {
            //new object[] { "437162", "London", 500 },
            new object[] { "357389", "Mumbai", 1 }
        };

        [Theory(DisplayName = "SearchToBookSingleRoomFlow")]
        [MemberData(nameof(SearchData))]
        [Trait("TestCategory", "Smoke")]
        [AllureSuite("Smoke")]
        public async Task SearchToBookSingleRoomFlow(string locationId, string locationName, int expectedCount)
        {
            var pipeline = new Pipeline<LocationRequest, BookResponse>();
            pipeline.AddPipe(new SelectLocation())
                    .AddPipe(new BuildSearchRequest())
                    .AddPipe(new BuildSearchRequestDefaultAssertions())
                    .AddPipe(new SearchHotels())
                    .AddPipe(new SearchHotelsDefaultAssertions(expectedCount))
                    .AddPipe(new SelectHotel())
                    .AddPipe(new SearchHotel())
                    .AddPipe(new SearchHotelDefaultAssertions())
                    .AddPipe(new SelectRoom(refundable: true))
                    .AddPipe(new Price())
                    .AddPipe(new SelectMockRateForBooking())
                    .AddPipe(new Book())
                    .AddPipe(new BookDefaultAssertions());

            var locationRequest = new LocationRequest { LocationId = locationId };
            await pipeline.ExecuteAsync(locationRequest);

            Assert.True(true);
        }

        //[Theory(DisplayName = "SearchToBookMultiRoomFlow")]
        [MemberData(nameof(SearchData))]
        [Trait("TestCategory", "Smoke")]
        [AllureSuite("Smoke")]
        public async Task SearchToBookMultiRoomFlow(string locationId, string locationName, int expectedCount)
        {
            var pipeline = new Pipeline<LocationRequest, BookResponse>();
            pipeline.AddPipe(new SelectLocation())
                    .AddPipe(new BuildSearchRequest(checkIn: DateTime.Now.AddMonths(4).AddDays(1), 
                                                    checkOut: DateTime.Now.AddMonths(4).AddDays(2),
                                                    occupancies: GetMultiOccupancy()))
                    .AddPipe(new BuildSearchRequestDefaultAssertions())
                    .AddPipe(new SearchHotels())
                    .AddPipe(new SearchHotelsDefaultAssertions(expectedCount))
                    .AddPipe(new SelectHotel())
                    .AddPipe(new SearchHotel())
                    .AddPipe(new SearchHotelDefaultAssertions())
                    .AddPipe(new SelectRoom(refundable: true))
                    .AddPipe(new Price())
                    .AddPipe(new SelectMockRateForBooking())
                    .AddPipe(new Book())
                    .AddPipe(new BookDefaultAssertions());

            var locationRequest = new LocationRequest { LocationId = locationId };
            await pipeline.ExecuteAsync(locationRequest);

            Assert.True(true);
        }

        private static List<Occupancy> GetMultiOccupancy()
        {
            var occupancies = new List<Occupancy>
            {
                new Occupancy() { NumOfAdults = 2, ChildAges = new List<int> { 5 } },
                new Occupancy() { NumOfAdults = 2, ChildAges = new List<int> { 7 } }
            };

            return occupancies;
        }

        //[Theory(DisplayName = "SearchResults")]
        [MemberData(nameof(SearchData))]
        [Trait("TestCategory", "Regression")]
        [AllureSuite("Regression")]
        public async Task AvailabilityCount(string locationId, string locationName, int expectedCount)
        {
            var locationData = await LocationApiClient.GetLocationData(locationId);
            var request = await AvailabilityRequest.GetBaseRequest(locationData);

            var response = await HotelApiClient.SearchHotelsWithCount(request);

            Assert.True(response.HotelCount >= expectedCount);
        }

        //[Theory(DisplayName = "MultiAvailabilityCount")]
        [MemberData(nameof(SearchData))]
        [Trait("TestCategory", "Regression")]
        [AllureSuite("Regression")]
        public async Task MultiAvailabilityCount(string locationId, string locationName, int expectedCount)
        {
            var locationData = await LocationApiClient.GetLocationData(locationId);
            var request = (await AvailabilityRequest.GetBaseRequest(locationData))
                .AddOccupancy(new List<Occupancy> { new() { NumOfAdults = 2, ChildAges = new List<int>() } });

            var response = await HotelApiClient.SearchHotelsWithCount(request);
            Assert.True(response.HotelCount >= expectedCount);
        }
    }
}
