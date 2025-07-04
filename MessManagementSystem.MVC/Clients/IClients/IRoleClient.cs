using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagementSystem.MVC.Services.IService
{
    public interface IRoleClient
    {
        Task<RoleResponseModel> GetByIdAsync(int id);
        Task<IEnumerable<RoleResponseModel>> GetAsync();
        Task<PaginatedResponseModel<RoleResponseModel>> GetAsync(PaginationParams paginationParams);
        Task<ApiResponse<bool>> AddAsync(RolesRequestModel model);
        Task<ApiResponse<bool>> UpdateAsync(string id, RolesRequestModel model);
        Task<string> DeleteAsync(string Id);
        Task<ApiResponse<bool>> AddPermission(RolePermissionRequestModel model);
    }
}
