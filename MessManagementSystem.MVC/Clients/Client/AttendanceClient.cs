using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.Helper;

namespace MessManagementSystem.MVC.Clients.Client
{
    public class AttendanceClient : IAttendanceClient
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ISiteConfiguration _siteConfiguration;
        public AttendanceClient(ISiteConfiguration siteConfiguration
                                , IHttpClientHelper httpClientHelper)
        {
            _siteConfiguration = siteConfiguration;
            _httpClientHelper = httpClientHelper;
        }
        public async Task<ApiResponse<string>> MarkAsync(AttendanceRequestModel input)
        {
            var uri = ApiEndPoint.MarkAttendance;
            var response = await _httpClientHelper.PostAsync<ApiResponse<string>>(uri, input);
            return response;
        }
        public async Task<PaginatedResponseModel<AttendanceResponseModel>> GetAsync(PaginationParams paginationParams)
        {
            var uri = ApiEndPoint.GetAttendance;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<AttendanceResponseModel>>(uri, paginationParams);
            return response;
        }
    }
}
