using Model;
using Model.BookingEngine;
using System.Text;
using Utility;

namespace Utility.WebClient
{
    public class HotelApiClient
    {
        public async static Task<int> GetHotelCount(LocationRequest request)
        {
            //Get polygon data from locationId
            var locationData = await LocationApiClient.GetLocationData(request.LocationId);

            //Send init request and then poll results
            var response = await SearchHotels(locationData);
            return response.HotelCount;
        }

        public static async Task<(int HotelCount, AvailabilityResponse AvailabilityResponse)> SearchHotels(LocationResponse locationResponse)
        {
            //Create search request
            var searchRequest = await AvailabilityRequest.GetBaseRequest(locationResponse);

            //INIT
            var initResponse = await GetInitToken(searchRequest);
            await Task.Delay(1000);

            //POLL
            return await GetResults(initResponse.Token);
        }
        public static async Task<(int HotelCount, AvailabilityResponse AvailabilityResponse)> SearchHotelsWithCount(AvailabilityRequest request)
        {
            //INIT
            var initResponse = await GetInitToken(request);
            await Task.Delay(1000);

            //POLL
            return await GetResults(initResponse.Token);
        }
        public static async Task<AvailabilityResponse> SearchHotels(AvailabilityRequest request)
        {
            //INIT
            var initResponse = await GetInitToken(request);
            await Task.Delay(1000);

            //POLL
            var results =  await GetResults(initResponse.Token);
            return results.AvailabilityResponse;
        }
        private static async Task<InitResponse> GetInitToken(AvailabilityRequest searchRequest)
        {
            using var client = new HttpWebClient(TestContext.AppSettings.HotelApiBaseUrl);

            var initEndPoint = "/api/hotel/availability/init";
            var headers = new Dictionary<string, string>
            {
                { "accountId", TestContext.AppSettings.AccountId },
                { "correlationId", TestContext.CurrentCorrelationId }
            };
            return await client.PostAsync<AvailabilityRequest, InitResponse>(initEndPoint, searchRequest, headers);
        }
        private static async Task<(int HotelCount, AvailabilityResponse AvailabilityResponse)> GetResults(string token)
        {
            var appSettings = TestContext.AppSettings;
            var resultsEndpoint = $"/api/hotel/availability/async/{token}/results";
            var headers = new Dictionary<string, string>
            {
                { "accountId", appSettings.AccountId },
                { "correlationId", TestContext.CurrentCorrelationId }
            };
            var completed = false;
            var totalUniqueHotels = new HashSet<string>();
            var nextResultsKey = string.Empty;
            var availabilityResponse = new AvailabilityResponse();

            using var client = new HttpWebClient(appSettings.HotelApiBaseUrl);

            do
            {
                if (!string.IsNullOrWhiteSpace(nextResultsKey))
                {
                    resultsEndpoint = $"/api/hotel/availability/async/{token}/results?nextResultsKey={nextResultsKey}";
                }
                var response = await client.GetAsync<ResultsResponse>(resultsEndpoint, headers);
                var hotels = response?.Hotels?.Select(x => x?.Id).ToList();

                if (response?.Hotels?.Count > 0)
                {
                    availabilityResponse.Currency = response.Currency;
                    availabilityResponse.Token = response.Token;
                    foreach (var hotel in response?.Hotels)
                    {
                        totalUniqueHotels.Add(hotel.Id);
                        availabilityResponse.Hotels ??= new List<Hotel>();
                        availabilityResponse.Hotels.Add(hotel);
                    }
                }
                if (!string.IsNullOrWhiteSpace(response.NextResultsKey))
                {
                    nextResultsKey = response.NextResultsKey;
                }

                if (response.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    completed = true;
                }
                else
                {
                    await Task.Delay(500);
                }
            } while (!completed);

            return (totalUniqueHotels.Count, availabilityResponse);
        }

        public static async Task<RoomsAndRatesResponse> SearchHotel(RoomsAndRatesRequest request)
        {
            var rrEndPoint = $"/api/hotel/{request.HotelId}/roomsandrates/{request.Token}";
            var appSettings = TestContext.AppSettings;

            var headers = new Dictionary<string, string>
            {
                { "accountId", appSettings.AccountId },
                { "correlationId", TestContext.CurrentCorrelationId }
            };

            using var client = new HttpWebClient(appSettings.HotelApiBaseUrl);
            return await client.PostAsync<RoomsAndRatesRequest, RoomsAndRatesResponse>(rrEndPoint, request, headers);
        }

        public static async Task<PriceResponse> Price(PriceRequest request)
        {
            var priceEndPoint = $"/api/hotel/{request.HotelId}/{request.Token}/price/recommendation/{request.RecommendationId}";
            var appSettings = TestContext.AppSettings;

            var headers = new Dictionary<string, string>
            {
                { "accountId", appSettings.AccountId },
                { "correlationId", TestContext.CurrentCorrelationId }
            };

            using var client = new HttpWebClient(appSettings.HotelApiBaseUrl);
            return await client.GetAsync<PriceResponse>(priceEndPoint, headers);
        }

        public static async Task<BookResponse> Book(BookingRequest bookRequest)
        {
            if (bookRequest.IsMock) //pipe
            {
                return new BookResponse
                {
                    BookingId = bookRequest.Bookingrefid,
                    BookingStatus = "Confirmed",
                    Token = bookRequest.Token,
                    CancellationToken = Convert.ToBase64String(Encoding.UTF8.GetBytes("test")),
                    HotelConfirmationNumber = "123",
                    ProviderConfirmationNumber = "123",
                    RoomConfirmationDetails = new List<RoomConfirmationInfo> { new() { ProviderConfirmationNumber = "123" } }
                };
            }

            var bookEndPoint = $"/api/hotel/{bookRequest.HotelId}/{bookRequest.Token}/book";
            var appSettings = TestContext.AppSettings;

            var headers = new Dictionary<string, string>
            {
                { "accountId", appSettings.AccountId },
                { "correlationId", TestContext.CurrentCorrelationId }
            };

            using var client = new HttpWebClient(appSettings.HotelApiBaseUrl);

            return await client.PostAsync<BookingRequest, BookResponse>(bookEndPoint, bookRequest, headers);
        }
    }
}
