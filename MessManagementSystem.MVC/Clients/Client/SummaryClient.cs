using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.Client
{
    public class SummaryClient : ISummaryClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ISiteConfiguration _siteConfiguration;
        public SummaryClient(ISiteConfiguration siteConfiguration
                                , HttpClient httpClient
                                , IHttpClientHelper httpClientHelper)
        {
            _siteConfiguration = siteConfiguration;
            _httpClient = httpClient;
            _httpClientHelper = httpClientHelper;
        }
        public async Task<SummaryResponseModel> GetSummaryAsync(int userId, DateTime date)
        {
            var uri = ApiEndPoint.GetSummary;
            var response = await _httpClientHelper.GetAsync<SummaryResponseModel>(uri);
            return response;
        }
    }
}
