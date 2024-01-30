using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.RoomsAndRates
{
    public class SelectHotel : Pipe<AvailabilityResponse, RoomsAndRatesRequest>
    {
        public string HotelId { get; }

        public SelectHotel(string hotelId = null)
        {
            HotelId = hotelId;
        }

        public override async Task<RoomsAndRatesRequest> ExecuteAsync(AvailabilityResponse input)
        {
            var hotelId = input.Hotels.FirstOrDefault().Id;
            if (!string.IsNullOrWhiteSpace(HotelId)) 
            {
                hotelId = HotelId;
            }
            return await Task.FromResult(new RoomsAndRatesRequest { HotelId = hotelId, Token = input.Token });
        }
    }
}

