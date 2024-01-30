using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Price
{
    public class SelectRoomDefaultAssertions : Pipe<PriceRequest, PriceRequest>
    {
        public override async Task<PriceRequest> ExecuteAsync(PriceRequest input)
        {

            Assert.True(!string.IsNullOrWhiteSpace(input.Token));
            Assert.True(!string.IsNullOrWhiteSpace(input.HotelId));
            Assert.True(!string.IsNullOrWhiteSpace(input.RecommendationId));
            
            return await Task.FromResult(input);
        }
    }
}

