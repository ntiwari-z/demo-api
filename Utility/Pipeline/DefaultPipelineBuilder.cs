using Model.BookingEngine;
using Utility.Pipeline.Availability;
using Utility.Pipeline.Book;
using Utility.Pipeline.Core;
using Utility.Pipeline.Location;
using Utility.Pipeline.Price;
using Utility.Pipeline.RoomsAndRates;
using Utility.Pipeline.Search;

namespace Utility
{
    public static class DefaultPipelineBuilder
    {
        public static Pipeline<LocationRequest, BookResponse> SearchToBookPipeline()
        {
            var pipeline = new Pipeline<LocationRequest, BookResponse>();
            pipeline.AddPipe(new SelectLocation())
                    .AddPipe(new BuildSearchRequest())
                    .AddPipe(new SearchHotels())
                    .AddPipe(new SelectHotel())
                    .AddPipe(new SearchHotel())
                    .AddPipe(new SelectRoom())
                    .AddPipe(new Price())
                    .AddPipe(new SelectMockRateForBooking())
                    .AddPipe(new Book());
            return pipeline;
        }

        public static Pipeline<LocationRequest, PriceResponse> SearchToPricePipeline()
        {
            var pipeline = new Pipeline<LocationRequest, PriceResponse>();
            pipeline.AddPipe(new SelectLocation())
                    .AddPipe(new BuildSearchRequest())
                    .AddPipe(new SearchHotels())
                    .AddPipe(new SelectHotel())
                    .AddPipe(new SearchHotel())
                    .AddPipe(new SelectRoom())
                    .AddPipe(new Price());
            return pipeline;
        }
    }
}

