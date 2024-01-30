using System.Text.Json.Serialization;

namespace Model.BookingEngine
{
    public class LocationResponse
    {
        [JsonPropertyName("shape")]
        public string Shape { get; set; }

        [JsonPropertyName("boundaries")]
        public List<List<Coordinates>> Boundaries { get; set; }

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("hierarchyPath")]
        public string HierarchyPath { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("referenceScore")]
        public int ReferenceScore { get; set; }

        [JsonPropertyName("isTermMatch")]
        public bool IsTermMatch { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("long")]
        public double Long { get; set; }
    }
}
