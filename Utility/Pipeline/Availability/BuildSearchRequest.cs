using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Availability
{
    public class BuildSearchRequest : Pipe<LocationResponse, AvailabilityRequest>
    {
        public DateTime? CheckIn { get; }
        public DateTime? CheckOut { get; }
        private List<Occupancy> Occupancies { get; }

        public BuildSearchRequest(DateTime? checkIn = null, DateTime? checkOut = null, List<Occupancy> occupancies = null)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            Occupancies = occupancies;
        }

        public override async Task<AvailabilityRequest> ExecuteAsync(LocationResponse input)
        {
            var availabilityRequest = await AvailabilityRequest.GetBaseRequest(input);

            if (Occupancies?.Count > 0) 
            {
                availabilityRequest.AddOccupancy(Occupancies);                
            }

            if (CheckIn.HasValue)
            {
                availabilityRequest.CheckIn = CheckIn.Value;
            }

            if (CheckOut.HasValue)
            {
                availabilityRequest.CheckOut = CheckOut.Value;
            }

            return availabilityRequest;
        }
    }
}