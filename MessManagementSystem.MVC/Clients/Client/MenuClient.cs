using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.Client
{
    public class MenuClient : IMenuClient
	{
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly ISiteConfiguration _siteConfiguration;
		public MenuClient(ISiteConfiguration siteConfiguration
								, HttpClient httpClient
								, IHttpClientHelper httpClientHelper)
		{
			_siteConfiguration = siteConfiguration;
			_httpClientHelper = httpClientHelper;
		}
		public async Task<ApiResponse<string>> AddAsync(MenuRequestModel MenuRequestModel)
		{
			var uri = ApiEndPoint.Add_Menu;
			var response = await _httpClientHelper.PostAsync<ApiResponse<string>>(uri, MenuRequestModel);
			return response;
		}

		public async Task<PaginatedResponseModel<MenuResponseModel>> GetAsync(PaginationParams pagination)
		{
			var uri = ApiEndPoint.Get_Menus;
			var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<MenuResponseModel>>(uri, pagination);
			return response;
		}
		public async Task<IEnumerable<MenuResponseModel>> GetAsync()
		{
			var uri = ApiEndPoint.Get_All_Menus;
			var response = await _httpClientHelper.GetAsync<PaginatedResponseModel<MenuResponseModel>>(uri);
			return response.Records;
		}

		public async Task<MenuResponseModel> GetByIdAsync(int Id)
		{
			var uri = $"{ApiEndPoint.Get_Menu}/{Id}";
			var response = await _httpClientHelper.GetAsync<MenuResponseModel>(uri);
			return response;
		}

		public async Task<string> UpdateAsync(int Id, MenuRequestModel MenuRequestModel)
		{
			var uri = $"{ApiEndPoint.Update_Menu}/{Id}";
			var response = await _httpClientHelper.PostAsync(uri, MenuRequestModel);
			return response;
		}
		public async Task<string> DeleteAsync(int Id)
		{
			var uri = $"{ApiEndPoint.Delete_Menu}/{Id}";
			var response = await _httpClientHelper.PostAsync(uri, null);
			return response;
		}

        public async Task<List<WeeklyMenuViewModel>> GetWeeklyMenuAsync()
        {
            var uri = ApiEndPoint.Get_Weekly_Menu;
            var response = await _httpClientHelper.GetAsync<List<WeeklyMenuViewModel>>(uri);
            return response;
        }
    }
}
