using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.Client
{
	public class StudentClient : IStudentClient
	{
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly ISiteConfiguration _siteConfiguration;
		public StudentClient(ISiteConfiguration siteConfiguration
								, IHttpClientHelper httpClientHelper)
		{
			_siteConfiguration = siteConfiguration;
			_httpClientHelper = httpClientHelper;
        }
		public async Task<StudentResponseModel> GetStudent(int Id)
		{
			var uri = $"{ApiEndPoint.GetStudent}/{Id}";
			var response = await _httpClientHelper.GetAsync<StudentResponseModel>(uri);
			return response;
		}

		
		public async Task<ApiResponse<string>> CreateFeedback(FeedbackRequestModel input)
		{
			var uri = ApiEndPoint.AddFeedBack;
			var response = await _httpClientHelper.PostAsync<ApiResponse<string>>(uri, input);
			return response;
		}

		public async Task<ApiResponse<List<FeedbackResponseModel>>> GetFeedbacks()
		{
			var uri = ApiEndPoint.GetFeedbacks;
			var response = await _httpClientHelper.GetAsync<ApiResponse<List<FeedbackResponseModel>>>(uri);
			return response;
		}

		

        public async Task<List<AccountsResponseModel>> GetStatement(int Id)
        {
            var uri = $"{ApiEndPoint.GetStatement}/{Id}";
            var response = await _httpClientHelper.GetAsync<List<AccountsResponseModel>>(uri);
            return response;
        }
    }
}
