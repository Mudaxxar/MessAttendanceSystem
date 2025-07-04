using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IPermissionsService
	{
		Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync(PaginationParams paginationParams);
		Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync();
		Task<ApiResponse<bool>> AddAsync(PermissionRequestModel model);
		Task<ApiResponse<bool>> UpdateAsync(int Id, PermissionRequestModel model);
		Task<PermissionResponseModel> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);

	}
}
