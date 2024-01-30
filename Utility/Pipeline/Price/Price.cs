using Model.BookingEngine;
using Utility.Pipeline.Core;
using Utility.WebClient;

namespace Utility.Pipeline.Price
{
    public class Price : Pipe<PriceRequest, PriceResponse>
    {
        public override async Task<PriceResponse> ExecuteAsync(PriceRequest input)
        {
            return await HotelApiClient.Price(input);
        }
    }
}