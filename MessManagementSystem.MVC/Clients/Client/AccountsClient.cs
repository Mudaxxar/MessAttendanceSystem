using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.Client
{
	public class AccountsClient : IAccounsClient
	{
		private readonly HttpClient _httpClient;
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly ISiteConfiguration _siteConfiguration;

		public AccountsClient(HttpClient httpClient
			, IHttpClientHelper httpClientHelper
			, ISiteConfiguration siteConfiguration)
		{
			_httpClient = httpClient;
			_httpClientHelper = httpClientHelper;
			_siteConfiguration = siteConfiguration;
		}

		public async Task<PaginatedResponseModel<MonthlyClosingResponseModel>> GetMonthlyClosingAsync(PaginationParams paginationParams)
		{
			var uri = ApiEndPoint.GetMonthlyClosing;
			var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<MonthlyClosingResponseModel>>(uri, paginationParams);
			return response;
		}

        public async Task<PaginatedResponseModel<StudentClosingResponse>> GetStudentStatementAsync(StudentStatementRequestModel requestModel)
        {
            var uri = ApiEndPoint.GetStudentsStatement;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<StudentClosingResponse>>(uri, requestModel);
            return response;
        }
    }
}
