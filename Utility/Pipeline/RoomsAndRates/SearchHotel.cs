using Model.BookingEngine;
using Utility.Pipeline.Core;
using Utility.WebClient;

namespace Utility.Pipeline.RoomsAndRates
{
    public class SearchHotel : Pipe<RoomsAndRatesRequest, RoomsAndRatesResponse>
    {
        public override async Task<RoomsAndRatesResponse> ExecuteAsync(RoomsAndRatesRequest input)
        {
            return await HotelApiClient.SearchHotel(input);
        }
    }
}

