using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Book
{
    public class BookDefaultAssertions : Pipe<BookResponse, BookResponse>
    {
        public override Task<BookResponse> ExecuteAsync(BookResponse input)
        {
            Assert.Equal("Confirmed", input.BookingStatus);
            return Task.FromResult(input);
        }
    }
}