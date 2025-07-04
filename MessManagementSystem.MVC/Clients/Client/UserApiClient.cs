using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Services.IService;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagementSystem.MVC.Services.Service
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ISiteConfiguration _siteConfiguration;
        public UserApiClient(HttpClient httpClient, ISiteConfiguration siteConfiguration)
        {
            _httpClient = httpClient;
            _siteConfiguration = siteConfiguration;
        }

        public async Task<PaginatedResponseModel<UserResponseModel>> GetUsers(PaginationParams paginationParams)
        {
            var uri = $"{_siteConfiguration.ApiBaseUrl}{ApiEndPoint.GetUsers}";
            var jsonData = JsonConvert.SerializeObject(paginationParams);
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigService.GetJwtToken());

            var response = _httpClient.PostAsync(uri, body).Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<UserResponseModel>>(contents);
            return result;
        }

        public async Task<UserManagerResponseModel> LoginAsync(LoginRequestModel requestModel)
        {
            try { 
            var uri = $"{_siteConfiguration.ApiBaseUrl}{ApiEndPoint.LoginUser}";

            var jsonData = JsonConvert.SerializeObject(requestModel);
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(uri, body).Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(contents);
            return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserManagerResponseModel> RegisterAsync(RegistrationRequestModel requestModel)
        {
            var uri = $"{_siteConfiguration.ApiBaseUrl}{ApiEndPoint.RegisterUser}";

            var jsonData = JsonConvert.SerializeObject(requestModel);
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(uri, body).Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(contents);
            return result;
        }

	

		public async Task<UserManagerResponseModel> UserStatus(int id)
        {
            var uri = $"{_siteConfiguration.ApiBaseUrl}{ApiEndPoint.UserStatus}/{id}";
            var response = await _httpClient.PostAsync(uri, null);
            var contents = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<UserManagerResponseModel>(contents);
            return result;
        }
		public Task<double> UsersCount()
		{
			var uri = $"{_siteConfiguration.ApiBaseUrl}{ApiEndPoint.UsersCount}";
            var response = _httpClient.GetAsync(uri).Result;
			if (response.IsSuccessStatusCode)
			{
				var contents = response.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<double>(contents);
				return Task.FromResult(result);
			}
			else
			{
				return Task.FromResult(0.0);
			}
		}
	}
}
