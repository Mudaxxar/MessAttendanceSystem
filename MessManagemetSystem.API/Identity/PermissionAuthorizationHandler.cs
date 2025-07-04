﻿using Microsoft.AspNetCore.Authorization;

namespace MessManagemetSystem.API.Identity
{
	public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
	{
		public PermissionAuthorizationHandler()
		{

		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
														PermissionRequirement requirement)
		{
			var permissions = context
				.User
				.Claims
				.Where(x => x.Type == CustomClaims.Permissions)
				.Select(x => x.Value)
				.ToHashSet();





			if (permissions.Contains(requirement.Permission))
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
		}
	}
}
