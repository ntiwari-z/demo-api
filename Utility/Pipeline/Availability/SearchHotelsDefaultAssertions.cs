using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Search
{
    public class SearchHotelsDefaultAssertions : Pipe<AvailabilityResponse, AvailabilityResponse>
    {
        public int ExpectedCount { get; }

        public SearchHotelsDefaultAssertions(int expectedCount)
        {
            ExpectedCount = expectedCount;
        }

        public override async Task<AvailabilityResponse> ExecuteAsync(AvailabilityResponse input)
        {
            Assert.True(!string.IsNullOrWhiteSpace(input.Token));
            Assert.True(input.Hotels.Count > 0);
            Assert.True(input.Hotels.Count >= ExpectedCount);

            return await Task.FromResult(input);
        }
    }
}

