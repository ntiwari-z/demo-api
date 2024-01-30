using Model;
using Model.BookingEngine;
using System.Text;
using Utility;

namespace Utility.WebClient
{
    public class LocationApiClient
    {
        public static async Task<LocationResponse> GetLocationData(string locationId)
        {
            using var client = new HttpWebClient(TestContext.AppSettings.LocationBaseUrl);
            var endPoint = $"/api/locations/locationcontent/location/{locationId}";
            return await client.GetAsync<LocationResponse>(endPoint);
        }
    }
}
