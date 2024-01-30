using Model.BookingEngine;
using Utility.Pipeline.Core;

namespace Utility.Pipeline.Price
{
    public class SelectRoom : Pipe<RoomsAndRatesResponse, PriceRequest>
    {
        public bool Refundable { get; }

        public SelectRoom(bool refundable = false)
        {
            Refundable = refundable;
        }

        public override async Task<PriceRequest> ExecuteAsync(RoomsAndRatesResponse input)
        {
            var recommendationId = string.Empty;
            if (Refundable)
            {
                var refundableRateIds = input.Hotel.Rates.Where(x => x.Refundability.Equals("refundable", StringComparison.OrdinalIgnoreCase)).Select(x => x.Id).ToList();
                bool found = false;
                foreach (var recommendation in input.Hotel.Recommendations)
                {
                    foreach (var rate in recommendation.Rates)
                    {
                        if (refundableRateIds.Contains(rate))
                        {
                            recommendationId = recommendation.Id;
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
            }

            return await Task.FromResult(new PriceRequest { HotelId = input.Hotel.Id, Token = input.Token, RecommendationId = recommendationId });
        }
    }
}

