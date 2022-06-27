using System.Net;
using System.Text;
using System.Text.Json;

namespace MyRoadMap.WebServer
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<T> Get<T>(string url)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    var result = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
                    return result;
                default:
                    throw new Exception(content);
            }
        }

        internal async Task<T> Put<T>(string url, T model)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Put, url);
            httpRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    var result = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
                    return result;
                default:
                    throw new Exception(content);
            }
        }

        internal async Task<T> Post<T>(string url, T model)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    var result = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
                    return result;
                default:
                    throw new Exception(content);
            }
        }
    }
}
