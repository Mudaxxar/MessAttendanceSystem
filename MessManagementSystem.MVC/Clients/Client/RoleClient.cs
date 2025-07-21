using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.EndPoints;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagementSystem.MVC.Services.Service
{
    public class RoleClient : IRoleClient
    {
        private readonly IHttpClientHelper _httpClientHelper;
        public RoleClient(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task<PaginatedResponseModel<RoleResponseModel>> GetAsync(PaginationParams paginationParams)
        {
            var uri = ApiEndPoint.GetRoles;
            var response = await _httpClientHelper.PostAsync<PaginatedResponseModel<RoleResponseModel>>(uri, paginationParams);
            return response;
        }
        public async Task<IEnumerable<RoleResponseModel>> GetAsync()
        {
            var uri = ApiEndPoint.GetAllRoles;
            var response = await _httpClientHelper.GetAsync<PaginatedResponseModel<RoleResponseModel>>(uri);
            var userRoles = response.Records.Select(r => new RoleResponseModel
            {
                Id = r.Id,
                Name = r.Name,
            });
            return userRoles;
        }
        public async Task<RoleResponseModel> GetByIdAsync(int id)
        {
            var uri = $"{ApiEndPoint.GetRole}/{id}";
            var response = await _httpClientHelper.GetAsync<RoleResponseModel>(uri);
            return response;
        }
        public async Task<ApiResponse<bool>> AddAsync(RolesRequestModel model)
        {
            var uri = ApiEndPoint.AddRoles;
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateAsync(string id, RolesRequestModel model)
        {
            var uri = $"{ApiEndPoint.Update_Role}/{id}";
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }
        public async Task<string> DeleteAsync(string id)
        {
            var uri = $"{ApiEndPoint.Delete_Role}/{id}";
            var response = await _httpClientHelper.PostAsync(uri, null);
            return response;
        }

        public async Task<ApiResponse<bool>> AddPermission(RolePermissionRequestModel model)
        {
            var uri = ApiEndPoint.AddPermission;
            var response = await _httpClientHelper.PostAsync<ApiResponse<bool>>(uri, model);
            return response;
        }
    }
}
