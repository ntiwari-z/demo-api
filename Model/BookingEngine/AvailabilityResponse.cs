using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class InitResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }

    public class AvailabilityResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("hotels")]
        public List<Hotel> Hotels { get; set; }
    }

    public class ResultsResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("expectedHotelCount")]
        public int ExpectedHotelCount { get; set; }

        [JsonPropertyName("completedHotelCount")]
        public int CompletedHotelCount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("nextResultsKey")]
        public string NextResultsKey { get; set; }

        [JsonPropertyName("hotels")]
        public List<Hotel> Hotels { get; set; }
    }

    public class CancellationPolicy
    {
        [JsonPropertyName("rules")]
        public List<Rule> Rules { get; set; }
    }

    public class Hotel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("relevanceScore")]
        public double RelevanceScore { get; set; }

        [JsonPropertyName("rate")]
        public Rate Rate { get; set; }

        [JsonPropertyName("isNewInResult")]
        public bool IsNewInResult { get; set; }

        [JsonPropertyName("moreRatesExpected")]
        public bool MoreRatesExpected { get; set; }

        [JsonPropertyName("isRecommended")]
        public bool IsRecommended { get; set; }

        [JsonPropertyName("options")]
        public Options Options { get; set; }

        [JsonPropertyName("priceComparison")]
        public List<PriceComparison> PriceComparison { get; set; }
    }

    public class Offer
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("discountOffer")]
        public double DiscountOffer { get; set; }

        [JsonPropertyName("percentageDiscountOffer")]
        public int PercentageDiscountOffer { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("freeBreakfast")]
        public bool FreeBreakfast { get; set; }

        [JsonPropertyName("freeCancellation")]
        public bool FreeCancellation { get; set; }

        [JsonPropertyName("refundable")]
        public bool Refundable { get; set; }

        [JsonPropertyName("payAtHotel")]
        public bool PayAtHotel { get; set; }

        [JsonPropertyName("contractedRateExists")]
        public bool ContractedRateExists { get; set; }
    }

    public class PriceComparison
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("rate")]
        public Rate Rate { get; set; }

        [JsonPropertyName("provider")]
        public Provider Provider { get; set; }

        [JsonPropertyName("roomName")]
        public string RoomName { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Provider
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("logoUrl")]
        public string LogoUrl { get; set; }
    }

    public class Rate
    {
        [JsonPropertyName("supplierBaseRate")]
        public double SupplierBaseRate { get; set; }

        [JsonPropertyName("supplierPublishedRate")]
        public double SupplierPublishedRate { get; set; }

        [JsonPropertyName("supplierPublishedBaseRate")]
        public double SupplierPublishedBaseRate { get; set; }

        [JsonPropertyName("supplierTotalRate")]
        public double SupplierTotalRate { get; set; }

        [JsonPropertyName("totalRate")]
        public double TotalRate { get; set; }

        [JsonPropertyName("publishedRate")]
        public double PublishedRate { get; set; }

        [JsonPropertyName("baseRate")]
        public double BaseRate { get; set; }

        [JsonPropertyName("commission")]
        public double Commission { get; set; }

        [JsonPropertyName("taxes")]
        public double Taxes { get; set; }

        [JsonPropertyName("fees")]
        public double Fees { get; set; }

        [JsonPropertyName("discounts")]
        public double Discounts { get; set; }

        [JsonPropertyName("providerId")]
        public string ProviderId { get; set; }

        [JsonPropertyName("providerName")]
        public string ProviderName { get; set; }

        [JsonPropertyName("offer")]
        public Offer Offer { get; set; }

        [JsonPropertyName("distributionType")]
        public string DistributionType { get; set; }

        [JsonPropertyName("distributionChannel")]
        public string DistributionChannel { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("payAtHotel")]
        public bool PayAtHotel { get; set; }

        [JsonPropertyName("otherRateComponents")]
        public List<object> OtherRateComponents { get; set; }

        [JsonPropertyName("publishedBaseRate")]
        public double PublishedBaseRate { get; set; }

        [JsonPropertyName("cancellationPolicies")]
        public List<CancellationPolicy> CancellationPolicies { get; set; }

        [JsonPropertyName("additionalCharges")]
        public List<object> AdditionalCharges { get; set; }

        [JsonPropertyName("availability")]
        public int Availability { get; set; }

        [JsonPropertyName("base")]
        public double Base { get; set; }

        [JsonPropertyName("hotelFees")]
        public double HotelFees { get; set; }
    }

    public class Rule
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("valueType")]
        public string ValueType { get; set; }

        [JsonPropertyName("estimatedValue")]
        public double EstimatedValue { get; set; }

        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime End { get; set; }
    }


}
