using MessManagemetSystem.API.Identity;

namespace MessManagemetSystem.API.Repository.IRepositories
{
	public interface IRolePermissionsRepository
	{
		Task<bool> AddRolePermissions(int roleId, int permissionId);
		Task<bool> GetAny(int roleId, int permissionId);
		Task<bool> GetRoleWithPermission(int permissionId);
		Task<IEnumerable<RolePermissionEntity>> GetRolePermissions();
	}
}
