using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class BookingRequest
    {
        [JsonIgnore]
        public string HotelId { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        [JsonIgnore]
        public bool IsMock { get; set; }
        
        [JsonPropertyName("rateids")]
        public List<string> Rateids { get; set; }

        [JsonPropertyName("bookingrefid")]
        public string Bookingrefid { get; set; }

        [JsonPropertyName("roomsallocations")]
        public List<Roomsallocation> Roomsallocations { get; set; }

        [JsonPropertyName("billingcontact")]
        public Billingcontact Billingcontact { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("line1")]
        public string Line1 { get; set; }

        [JsonPropertyName("line2")]
        public string Line2 { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("postalcode")]
        public string Postalcode { get; set; }
    }

    public class Billingcontact
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("middlename")]
        public string Middlename { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }
    }

    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class Contact
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class Guest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("middlename")]
        public string Middlename { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pancardnumber")]
        public string Pancardnumber { get; set; }

        [JsonPropertyName("passport")]
        public object Passport { get; set; }
    }

    public class Roomsallocation
    {
        [JsonPropertyName("roomid")]
        public string Roomid { get; set; }

        [JsonPropertyName("rateid")]
        public string Rateid { get; set; }

        [JsonPropertyName("guests")]
        public List<Guest> Guests { get; set; }
    }
}
