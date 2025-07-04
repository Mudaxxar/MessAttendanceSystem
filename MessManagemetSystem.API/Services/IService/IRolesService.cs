using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IRolesService
	{
		Task<ApiResponse<bool>> AddRole(RolesRequestModel model);
		Task<ApiResponse<bool>> UpdateRole(int roleId, RolesRequestModel model);
		Task<ApiResponse<bool>> DeleteRole(int Id);
		Task<UserRoles> GetRoleById(int id);
		Task<PaginatedResponseModel<UserRoles>> GetRoles();
		Task<PaginatedResponseModel<UserRoles>> GetRoles(PaginationParams paginationParams);


	}
}
