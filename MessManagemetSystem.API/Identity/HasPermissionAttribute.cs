using MessManagemetSystem.API.Enums;
using Microsoft.AspNetCore.Authorization;

namespace MessManagemetSystem.API.Identity
{
	public sealed class HasPermissionAttribute : AuthorizeAttribute
	{
		public HasPermissionAttribute(AdminPermissions permission)
			: base(policy: permission.ToString())
		{

		}
	}
}
