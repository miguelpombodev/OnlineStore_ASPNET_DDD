using System.Net;
using Newtonsoft.Json;
using OnlineStore.Domain.DTO.HttpClient;
using OnlineStore.Domain.Interfaces.Services;

namespace OnlineStore.Services.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _client;

        public HttpClientService()
        {
            HttpClientHandler handler = new()
            {
                AutomaticDecompression = DecompressionMethods.All
            };

            _client = new HttpClient(handler);
        }
        public async Task<object> GetAsync(string uri)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                var raw_result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StrapiGetModel<TechnicalInfosResponse>>(raw_result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}