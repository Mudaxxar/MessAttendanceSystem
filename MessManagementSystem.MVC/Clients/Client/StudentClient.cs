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
		private readonly HttpClient _httpClient;
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly ISiteConfiguration _siteConfiguration;
		public StudentClient(ISiteConfiguration siteConfiguration
								, HttpClient httpClient
								, IHttpClientHelper httpClientHelper)
		{
			_siteConfiguration = siteConfiguration;
			_httpClient = httpClient;
			_httpClientHelper = httpClientHelper;
		}
		public async Task<StudentResponseModel> GetStudent(int Id)
		{
			var uri = $"{ApiEndPoint.GetStudent}/{Id}";
			var response = await _httpClientHelper.GetAsync<StudentResponseModel>(uri);
			return response;
		}

		public async Task<ApiResponse<string>> MarkAttendance(AttendanceRequestModel input)
		{
			var uri = ApiEndPoint.MarkAttendance;
			var response = await _httpClientHelper.PostAsync<ApiResponse<string>>(uri, input);
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
	}
}
