using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.BookingEngine
{
    public class RoomsAndRatesResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("hotel")]
        public HotelRR Hotel { get; set; }

        [JsonPropertyName("rmRequestJson")]
        public RmRequestJson RmRequestJson { get; set; }
    }

    public class AllowedCountry
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("states")]
        public List<State> States { get; set; }
    }

    public class AllowedCreditCard
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class Area
    {
        [JsonPropertyName("squareFeet")]
        public string SquareFeet { get; set; }
    }

    public class Bed
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class BoardBasis
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    //public class CancellationPolicy
    //{
    //    [JsonPropertyName("rules")]
    //    public List<Rule> Rules { get; set; }
    //}

    public class Commission
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class CommonFields
    {
        [JsonPropertyName("checkInDate")]
        public DateTime CheckInDate { get; set; }

        [JsonPropertyName("checkOutDate")]
        public DateTime CheckOutDate { get; set; }

        [JsonPropertyName("adultCount")]
        public string AdultCount { get; set; }

        [JsonPropertyName("childCount")]
        public string ChildCount { get; set; }

        [JsonPropertyName("locationId")]
        public object LocationId { get; set; }

        [JsonPropertyName("searchId")]
        public string SearchId { get; set; }
    }

    public class DailyRate
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("taxIncluded")]
        public bool TaxIncluded { get; set; }

        [JsonPropertyName("discount")]
        public double Discount { get; set; }
    }

    public class Facility
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class HotelRR
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }

        [JsonPropertyName("rates")]
        public List<RateRR> Rates { get; set; }

        [JsonPropertyName("recommendations")]
        public List<Recommendation> Recommendations { get; set; }

        [JsonPropertyName("standardizedRooms")]
        public List<StandardizedRoom> StandardizedRooms { get; set; }

        [JsonPropertyName("priceComparison")]
        public List<PriceComparisonRR> PriceComparison { get; set; }

        [JsonPropertyName("recommendationGroups")]
        public RecommendationGroups RecommendationGroups { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }
    }

    public class OccupancyRR
    {
        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("stdRoomId")]
        public string StdRoomId { get; set; }

        [JsonPropertyName("numOfAdults")]
        public int NumOfAdults { get; set; }

        [JsonPropertyName("numOfChildren")]
        public int NumOfChildren { get; set; }

        [JsonPropertyName("childAges")]
        public List<object> ChildAges { get; set; }
    }

    public class OtherField
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("hotelName")]
        public object HotelName { get; set; }

        [JsonPropertyName("chainCode")]
        public string ChainCode { get; set; }

        [JsonPropertyName("chainName")]
        public string ChainName { get; set; }

        [JsonPropertyName("distance")]
        public string Distance { get; set; }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("starRating")]
        public string StarRating { get; set; }

        [JsonPropertyName("baseAmount")]
        public string BaseAmount { get; set; }

        [JsonPropertyName("totalAmount")]
        public string TotalAmount { get; set; }

        [JsonPropertyName("commission")]
        public string Commission { get; set; }

        [JsonPropertyName("providerId")]
        public string ProviderId { get; set; }

        [JsonPropertyName("providerName")]
        public string ProviderName { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("potentialMarginPercentage")]
        public string PotentialMarginPercentage { get; set; }

        [JsonPropertyName("discount")]
        public string Discount { get; set; }

        [JsonPropertyName("leadDays")]
        public string LeadDays { get; set; }

        [JsonPropertyName("guestCount")]
        public string GuestCount { get; set; }

        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        [JsonPropertyName("PublishedBaseRate")]
        public string PublishedBaseRate { get; set; }
    }

    public class OtherRateComponent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("percentage")]
        public double Percentage { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Policy
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class PriceComparisonRR
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

    //public class Provider
    //{
    //    [JsonPropertyName("name")]
    //    public string Name { get; set; }

    //    [JsonPropertyName("logoUrl")]
    //    public string LogoUrl { get; set; }
    //}

    public class Qualifier
    {
        [JsonPropertyName("AccountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("ChannelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("SegmentId")]
        public object SegmentId { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }
    }

    public class RateRR
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("availability")]
        public int Availability { get; set; }

        [JsonPropertyName("needsPriceCheck")]
        public bool NeedsPriceCheck { get; set; }

        [JsonPropertyName("isPackageRate")]
        public bool IsPackageRate { get; set; }

        [JsonPropertyName("providerId")]
        public string ProviderId { get; set; }

        [JsonPropertyName("providerName")]
        public string ProviderName { get; set; }

        [JsonPropertyName("isContractedRate")]
        public bool IsContractedRate { get; set; }

        [JsonPropertyName("occupancies")]
        public List<OccupancyRR> Occupancies { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("baseRate")]
        public double BaseRate { get; set; }

        [JsonPropertyName("totalRate")]
        public double TotalRate { get; set; }

        [JsonPropertyName("minSellingRate")]
        public double MinSellingRate { get; set; }

        [JsonPropertyName("publishedRate")]
        public double PublishedRate { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("taxes")]
        public List<Taxis> Taxes { get; set; }

        [JsonPropertyName("commission")]
        public Commission Commission { get; set; }

        [JsonPropertyName("dailyRates")]
        public List<DailyRate> DailyRates { get; set; }

        [JsonPropertyName("refundable")]
        public bool Refundable { get; set; }

        [JsonPropertyName("refundability")]
        public string Refundability { get; set; }

        [JsonPropertyName("allGuestsInfoRequired")]
        public bool AllGuestsInfoRequired { get; set; }

        [JsonPropertyName("onlineCancellable")]
        public bool OnlineCancellable { get; set; }

        [JsonPropertyName("specialRequestSupported")]
        public bool SpecialRequestSupported { get; set; }

        [JsonPropertyName("payAtHotel")]
        public bool PayAtHotel { get; set; }

        [JsonPropertyName("cardRequired")]
        public bool CardRequired { get; set; }

        [JsonPropertyName("policies")]
        public List<Policy> Policies { get; set; }

        [JsonPropertyName("boardBasis")]
        public BoardBasis BoardBasis { get; set; }

        [JsonPropertyName("offers")]
        public List<object> Offers { get; set; }

        [JsonPropertyName("cancellationPolicies")]
        public List<CancellationPolicy> CancellationPolicies { get; set; }

        [JsonPropertyName("includes")]
        public List<string> Includes { get; set; }

        [JsonPropertyName("depositRequired")]
        public bool DepositRequired { get; set; }

        [JsonPropertyName("guaranteeRequired")]
        public bool GuaranteeRequired { get; set; }

        [JsonPropertyName("otherRateComponents")]
        public List<OtherRateComponent> OtherRateComponents { get; set; }

        [JsonPropertyName("distributionType")]
        public string DistributionType { get; set; }

        [JsonPropertyName("distributionChannel")]
        public string DistributionChannel { get; set; }

        [JsonPropertyName("publishedBaseRate")]
        public double PublishedBaseRate { get; set; }

        [JsonPropertyName("supplierPublishedBaseRate")]
        public double SupplierPublishedBaseRate { get; set; }

        [JsonPropertyName("supplierPublishedRate")]
        public double SupplierPublishedRate { get; set; }

        [JsonPropertyName("isPassportMandatory")]
        public bool IsPassportMandatory { get; set; }

        [JsonPropertyName("isPANMandatory")]
        public bool IsPANMandatory { get; set; }

        [JsonPropertyName("providerHotelId")]
        public string ProviderHotelId { get; set; }

        [JsonPropertyName("allowedCreditCards")]
        public List<AllowedCreditCard> AllowedCreditCards { get; set; }

        [JsonPropertyName("allowedCountries")]
        public List<AllowedCountry> AllowedCountries { get; set; }
    }

    public class Rate2
    {
        [JsonPropertyName("base")]
        public double Base { get; set; }

        [JsonPropertyName("taxes")]
        public double Taxes { get; set; }

        [JsonPropertyName("hotelFees")]
        public double HotelFees { get; set; }
    }

    public class Recommendation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rates")]
        public List<string> Rates { get; set; }

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }
    }

    public class RecommendationGroups
    {
    }

    public class RmRequestJson
    {
        [JsonPropertyName("Qualifier")]
        public Qualifier Qualifier { get; set; }

        [JsonPropertyName("CommonFields")]
        public CommonFields CommonFields { get; set; }

        [JsonPropertyName("OtherFields")]
        public List<OtherField> OtherFields { get; set; }

        [JsonPropertyName("RequestedCurrency")]
        public string RequestedCurrency { get; set; }

        [JsonPropertyName("RecommendationChannelName")]
        public string RecommendationChannelName { get; set; }

        [JsonPropertyName("EnableDynamicMargin")]
        public bool EnableDynamicMargin { get; set; }
    }

    public class Room
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("beds")]
        public List<Bed> Beds { get; set; }

        [JsonPropertyName("smokingAllowed")]
        public bool SmokingAllowed { get; set; }

        [JsonPropertyName("facilities")]
        public List<Facility> Facilities { get; set; }
    }

    //public class Rule
    //{
    //    [JsonPropertyName("value")]
    //    public double Value { get; set; }

    //    [JsonPropertyName("valueType")]
    //    public string ValueType { get; set; }

    //    [JsonPropertyName("estimatedValue")]
    //    public double EstimatedValue { get; set; }

    //    [JsonPropertyName("start")]
    //    public DateTime Start { get; set; }

    //    [JsonPropertyName("end")]
    //    public DateTime End { get; set; }
    //}

    public class StandardizedRoom
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("facilities")]
        public List<Facility> Facilities { get; set; }

        [JsonPropertyName("maxGuestAllowed")]
        public int MaxGuestAllowed { get; set; }

        [JsonPropertyName("maxAdultAllowed")]
        public int MaxAdultAllowed { get; set; }

        [JsonPropertyName("maxChildrenAllowed")]
        public int MaxChildrenAllowed { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("views")]
        public List<object> Views { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("beds")]
        public List<Bed> Beds { get; set; }
    }

    public class State
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Taxis
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }


}
