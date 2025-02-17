using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.BingSearch
{
    public class BingSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly string _subscriptionKey;
        private const string Endpoint = "https://api.bing.microsoft.com/v7.0/search";


        public BingSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _subscriptionKey = "3e986a55614c4287b8ab426c7e05c58b";
        }

        public async Task<string> SearchAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("La requête ne peut pas être vide", nameof(query));

            var requestUri = $"{Endpoint}?q={Uri.EscapeDataString(query)}";
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
    }
}
