using Microsoft.AspNetCore.Authorization;

namespace MessManagemetSystem.API.Identity
{
	public class PermissionRequirement : IAuthorizationRequirement
	{
		public string Permission { get; }
		public PermissionRequirement(string permission)
		{
			Permission = permission;
		}
	}
}
