using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.RoomsAndRates
{
    public class SearchHotelDefaultAssertions : Pipe<RoomsAndRatesResponse, RoomsAndRatesResponse>
    {
        public override async Task<RoomsAndRatesResponse> ExecuteAsync(RoomsAndRatesResponse input)
        {
            Assert.True(input.Hotel != null);
            Assert.True(input.Hotel.Rates?.Count > 0);
            Assert.True(input.Hotel.Rooms?.Count > 0);
            Assert.True(input.Hotel.Recommendations?.Count > 0);
            Assert.True(input.Hotel.StandardizedRooms?.Count > 0);

            return await Task.FromResult(input);
        }
    }
}

