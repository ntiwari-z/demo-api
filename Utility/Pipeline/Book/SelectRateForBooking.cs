using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Book
{
    public class SelectRateForBooking : Pipe<PriceResponse, BookingRequest>
    {
        public override async Task<BookingRequest> ExecuteAsync(PriceResponse input)
        {
            return await Task.FromResult(new BookingRequest { HotelId = input.Hotel.Id, Token = input.Token });
        }
    }

    public class SelectMockRateForBooking : Pipe<PriceResponse, BookingRequest>
    {
        public override async Task<BookingRequest> ExecuteAsync(PriceResponse input)
        {
            return await Task.FromResult(new BookingRequest { IsMock = true, HotelId = input.Hotel.Id, Token = input.Token });
        }
    }
}