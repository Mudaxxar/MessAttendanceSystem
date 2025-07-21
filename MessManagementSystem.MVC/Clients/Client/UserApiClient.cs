using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Services.IService;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.MVC.Helper;

namespace MessManagementSystem.MVC.Services.Service
{
    public class UserApiClient : IUserApiClient
    {
        private readonly ISiteConfiguration _siteConfiguration;
		private readonly IHttpClientHelper _httpClientHelper;
		public UserApiClient( ISiteConfiguration siteConfiguration
            ,IHttpClientHelper httpClientHelper)
        {
            _siteConfiguration = siteConfiguration;
            _httpClientHelper = httpClientHelper;
        }

        public async Task<PaginatedResponseModel<UserResponseModel>> GetUsers(PaginationParams paginationParams)
        {
            var uri = $"{ApiEndPoint.GetUsers}";
            var response = _httpClientHelper.PostAsync(uri, paginationParams).Result;
            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<UserResponseModel>>(response);
            return result;
        }

        public async Task<UserManagerResponseModel> LoginAsync(LoginRequestModel requestModel)
        {
            try
            {
                var uri = $"{ApiEndPoint.LoginUser}";
                var response = await _httpClientHelper.PostAsync(uri, requestModel);
                var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(response);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserManagerResponseModel> RegisterAsync(RegistrationRequestModel requestModel)
        {
            var uri = $"{ApiEndPoint.RegisterUser}";
            var response = await _httpClientHelper.PostAsync(uri, requestModel);
            var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(response);
            return result;
        }
		public async Task<UserManagerResponseModel> UserStatus(int id)
        {
            var uri = $"{ApiEndPoint.UserStatus}/{id}";
            var response = await _httpClientHelper.PostAsync(uri, null);
            var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(response);
            return result;
        }
		public async Task<UserResponseModel> GetUserAsync(int Id)
		{
			var uri = $"{ApiEndPoint.GetStudent}/{Id}";
			var response = await _httpClientHelper.GetAsync<UserResponseModel>(uri);
			return response;
		}
        public async Task<UserManagerResponse> UpdateAsync(int Id, UserRequestModel model)
		{
			var uri = $"{ApiEndPoint.UpdateUser}/{Id}";
			var response = await _httpClientHelper.PostAsync<UserManagerResponse>(uri, model);
			return response;
		} 
        public async Task<UserManagerResponseModel> ResetPasswordAsync(ResetPasswordRequestModel model)
		{
			var uri = $"{ApiEndPoint.PasswordReset}";
			var response = await _httpClientHelper.PostAsync<UserManagerResponseModel>(uri, model);
			return response;
		}
		public async Task<double> UsersCount()
		{
			var uri = $"{ApiEndPoint.UsersCount}";
            var response = await _httpClientHelper.GetAsync(uri);
			if (response.Contains("Success"))
			{
				var result = JsonConvert.DeserializeObject<double>(response);
				return  await Task.FromResult(result);
			}
			else
			{
				return await Task.FromResult(0.0);
			}
		}
	}
}
