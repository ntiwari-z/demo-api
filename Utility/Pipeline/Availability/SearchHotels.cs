using Model.BookingEngine;
using Utility.Pipeline.Core;
using Utility.WebClient;

namespace Utility.Pipeline.Search
{
    public class SearchHotels : Pipe<AvailabilityRequest, AvailabilityResponse>
    {
        public override async Task<AvailabilityResponse> ExecuteAsync(AvailabilityRequest input)
        {
            return await HotelApiClient.SearchHotels(input);
        }
    }
}

