using Model;
using Model.BookingEngine;
using Utility.Pipeline.Core;
using Utility.WebClient;

namespace Utility.Pipeline.Location
{
    public class SelectLocation : Pipe<LocationRequest, LocationResponse>
    {
        public override async Task<LocationResponse> ExecuteAsync(LocationRequest input)
        {
            return await LocationApiClient.GetLocationData(input.LocationId);
        }
    }
}
