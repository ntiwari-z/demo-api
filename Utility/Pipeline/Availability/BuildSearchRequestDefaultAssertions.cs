using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Availability
{
    public class BuildSearchRequestDefaultAssertions : Pipe<AvailabilityRequest, AvailabilityRequest>
    {
        public override async Task<AvailabilityRequest> ExecuteAsync(AvailabilityRequest input)
        {
            Assert.True(!string.IsNullOrWhiteSpace(input.Currency));
            Assert.True(!string.IsNullOrWhiteSpace(input.ChannelId));
            Assert.True(!string.IsNullOrWhiteSpace(input.Culture));
            Assert.True(!string.IsNullOrWhiteSpace(input.CheckIn.ToString()));
            Assert.True(!string.IsNullOrWhiteSpace(input.CheckOut.ToString()));

            return await Task.FromResult(input);
        }
    }
}