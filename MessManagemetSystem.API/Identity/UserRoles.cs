using Microsoft.AspNetCore.Identity;

namespace MessManagemetSystem.API.Identity
{
	public class UserRoles : IdentityRole<int>
	{
		public bool IsDeleted { get; set; }
		public virtual ICollection<RolePermissionEntity> RolePermissions { get; set; }

	}
}
