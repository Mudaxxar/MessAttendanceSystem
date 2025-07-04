using MessManagementSystem.MVC.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MessManagementSystem.MVC.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly ISiteConfiguration _siteConfiguration;

        public HttpClientHelper(HttpClient httpClient, ISiteConfiguration siteConfiguration)
        {
            _httpClient = httpClient;
            _siteConfiguration = siteConfiguration;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigService.GetJwtToken());
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var url = $"{_siteConfiguration.ApiBaseUrl}{endpoint}";
            var body1 = JsonConvert.SerializeObject(data);
            var body = new StringContent(body1, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, body);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(contents);
                return result;
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(errorMessage);
            }

        }
        public async Task<string> PostAsync(string endpoint, object data)
        {
            var url = $"{_siteConfiguration.ApiBaseUrl}{endpoint}";
            var body1 = JsonConvert.SerializeObject(data);
            var body = new StringContent(body1, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, body);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var url = $"{_siteConfiguration.ApiBaseUrl}{endpoint}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                if (typeof(T) == typeof(byte[]))
                {
                    var bytContents = await response.Content.ReadAsByteArrayAsync();
                    return (T)(object)bytContents;

                }
                var contents = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<T>(contents);
                return result;

                // Return the file as a FileResult
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(errorMessage);
            }

        }

        public async Task<string> GetAsync(string endpoint)
        {
            var url = $"{_siteConfiguration.ApiBaseUrl}{endpoint}";
            var response = await _httpClient.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }
    }
}
