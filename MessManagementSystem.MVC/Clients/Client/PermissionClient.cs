using MessManagementSystem.Shared.Models;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models.RequestModels;


namespace MessManagementSystem.MVC.Services.Service
{
    public class PermissionService : IPermissionClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientHelper _httpClientHelper;
        public PermissionService(HttpClient httpClient
                                , IHttpClientHelper httpClientHelper)
        {
            _httpClient = httpClient;
            _httpClientHelper = httpClientHelper;
        }

        public async Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync(PaginationParams paginationParams)
        {
            var uri = ApiEndPoint.Get_Permissions;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<PermissionResponseModel>>(uri, paginationParams);
            return response;
        }
        public async Task<IEnumerable<PermissionResponseModel>> GetAsync()
        {
            var uri = ApiEndPoint.Get_All_Permissions;
            var response = await _httpClientHelper.GetAsync<PaginatedResponseModel<PermissionResponseModel>>(uri);
            var permissions = response.Records.Select(r => new PermissionResponseModel
            {
                Id = r.Id,
                Name = r.Name,
            });
            return permissions;
        }
        public async Task<PermissionResponseModel> GetByIdAsync(int id)
        {
            var uri = $"{ApiEndPoint.Get_PermissionById}/{id}";
            var response = await _httpClientHelper.GetAsync<PermissionResponseModel>(uri);
            return response;
        }
        public async Task<ApiResponse<bool>> AddAsync(PermissionRequestModel model)
        {
            var uri = ApiEndPoint.Add_Permission;
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, PermissionRequestModel model)
        {
            var uri = $"{ApiEndPoint.Update_Permission}/{id}";
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }
        public async Task<string> DeleteAsync(int id)
        {
            var uri = $"{ApiEndPoint.Delete_Permission}/{id}";
            var response = await _httpClientHelper.PostAsync(uri, null);
            return response;
        }

}
}
