using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IRolePermissionsService
	{
		Task<ApiResponse<bool>> AddRolePermission(RolePermissionRequestModel model);
	}
}
