using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.Client
{
	public class ExpenseHeadsClient : IExpenseHeadsClient
	{
		private readonly HttpClient _httpClient;
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly ISiteConfiguration _siteConfiguration;

		public ExpenseHeadsClient(HttpClient httpClient
			,IHttpClientHelper httpClientHelper
			, ISiteConfiguration siteConfiguration)
        {
			_httpClient = httpClient;
			_httpClientHelper = httpClientHelper;
			_siteConfiguration = siteConfiguration;
		}
        public async Task<ApiResponse<ExpenseHeadsResponseModel>> AddAsync(ExpenseHeadsRequestModel model)
		{
			var uri = ApiEndPoint.AddExpenseHead;
			var response = await _httpClientHelper.PostAsync<ApiResponse<ExpenseHeadsResponseModel>>(uri, model);
			return response;
		}

		public async Task<ApiResponse<bool>> DeleteAsync(int id)
		{
				var uri = $"{ApiEndPoint.DeleteExpenseHead}/{id}";
				var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, null);
				return response;
		}

		public async Task<ApiResponse<ExpenseHeadsResponseModel>> GetByIdAsync(int Id)
		{
			var uri = $"{ApiEndPoint.GetExpenseHead}/{Id}";
			var response = await _httpClientHelper.GetAsync<ApiResponse<ExpenseHeadsResponseModel>>(uri);
			return response;
		}

		public async Task<PaginatedResponseModel<ExpenseHeadsResponseModel>> GetAsync(PaginationParams paginationParams)
		{
			var uri = ApiEndPoint.GetExpenseHeads;
			var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<ExpenseHeadsResponseModel>>(uri, paginationParams);
			return response;
		}

		public async Task<ApiResponse<bool>> UpdateAsync(int Id, ExpenseHeadsRequestModel model)
		{
			var uri = $"{ApiEndPoint.UpdateExpenseHead}/{Id}";
			var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
			return response;
		}

        public async Task<List<ExpenseHeadsResponseModel>> GetAllAsync()
        {
            var uri = ApiEndPoint.GetExpenseHeadsAll;
            var response = await _httpClientHelper.GetAsync<List<ExpenseHeadsResponseModel>>(uri);
            return response;
            }
           
    }
}
