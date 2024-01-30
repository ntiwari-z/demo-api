using Model.BookingEngine;
using Utility.Pipeline.Core;
using Utility.WebClient;

namespace Utility.Pipeline.Book
{
    public class Book : Pipe<BookingRequest, BookResponse>
    {
        public override async Task<BookResponse> ExecuteAsync(BookingRequest input)
        {
            return await HotelApiClient.Book(input);
        }
    }
}