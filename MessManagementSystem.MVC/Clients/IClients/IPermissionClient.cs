using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Services.IService
{
    public interface IPermissionClient
    {
        Task<PermissionResponseModel> GetByIdAsync(int id);
        Task<IEnumerable<PermissionResponseModel>> GetAsync();
        Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync(PaginationParams paginationParams);
        Task<ApiResponse<bool>> AddAsync(PermissionRequestModel model);
        Task<ApiResponse<bool>> UpdateAsync(int id, PermissionRequestModel model);
        Task<string> DeleteAsync(int Id);
    }
}
