using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;

namespace MessManagementSystem.MVC.Clients.Client
{
   
    public class ExpenseClient : IExpenseClient
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ISiteConfiguration _siteConfiguration;

        public ExpenseClient(HttpClient httpClient
            , IHttpClientHelper httpClientHelper
            , ISiteConfiguration siteConfiguration)
        {
            _httpClientHelper = httpClientHelper;
            _siteConfiguration = siteConfiguration;
        }
        public async Task<ApiResponse<ExpenseResponseModel>> AddAsync(ExpenseRequestModel model)
        {
            var uri = ApiEndPoint.AddExpense;
            var response = await _httpClientHelper.PostAsync<ApiResponse<ExpenseResponseModel>>(uri, model);
            return response;
        }  
        public async Task<ApiResponse<ExpenseResponseModel>> AddMonthlyAsync(ExpenseRequestModel model)
        {
            var uri = ApiEndPoint.AddMonthlyExpense;
            var response = await _httpClientHelper.PostAsync<ApiResponse<ExpenseResponseModel>>(uri, model);
            return response;
        }
        public async Task<ApiResponse<bool>> AddMonthlyClosingAsync(int Id)
        {
            var uri = $"{ApiEndPoint.AddMonthlyClosing}/{Id}";
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, null);
            return response;
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var uri = $"{ApiEndPoint.DeleteExpense}/{id}";
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, null);
            return response;
        }

        public async Task<ApiResponse<ExpenseResponseModel>> GetByIdAsync(int Id)
        {
            var uri = $"{ApiEndPoint.GetExpense}/{Id}";
            var response = await _httpClientHelper.GetAsync<ApiResponse<ExpenseResponseModel>>(uri);
            return response;
        }

        public async Task<PaginatedResponseModel<ExpenseResponseModel>> GetAsync(PaginationParams paginationParams)
        {
            var uri = ApiEndPoint.GetExpenses;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<ExpenseResponseModel>>(uri, paginationParams);
            return response;
        } 
        public async Task<PaginatedResponseModel<ExpenseResponseModel>> GetMonthlyAsync(PaginationParams paginationParams)
        {
            var uri = ApiEndPoint.GetMonthlyExpenses;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<ExpenseResponseModel>>(uri, paginationParams);
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int Id, ExpenseRequestModel model)
        {
            var uri = $"{ApiEndPoint.UpdateExpense}/{Id}";
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }
    }
}
