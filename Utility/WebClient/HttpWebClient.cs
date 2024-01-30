using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Utility.WebClient
{
    public class HttpWebClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpWebClient(string baseUri)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest requestData, IDictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            request.Headers.Add("customer-ip", GetLocalIPAddress());
            WriteDataOnTestOutput("endpoint", endpoint);
            var requestString = JsonConvert.SerializeObject(requestData);
            WriteDataOnTestOutput("request-payload", requestString);
            request.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();
            WriteDataOnTestOutput("response-payload", responseContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(responseContent);
            }

            throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        private static void WriteDataOnTestOutput(string propertyName, string propertyValue)
        {
            XunitContext.Context.TestOutput.WriteLine("");
            XunitContext.Context.TestOutput.WriteLine(propertyName);
            XunitContext.Context.TestOutput.WriteLine(propertyValue);
            XunitContext.Context.TestOutput.WriteLine("");
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint, IDictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            request.Headers.Add("customer-ip", GetLocalIPAddress());
            WriteDataOnTestOutput("endpoint", endpoint);
            var response = await _httpClient.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();
            WriteDataOnTestOutput("response-Payload", responseText);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(responseText);
            }

            throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
}
