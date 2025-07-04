using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.IRepositories;
using MessManagemetSystem.API.Services.IService;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagemetSystem.API.Services.Service
{
    public class RolePermissionsService : IRolePermissionsService
	{
		private readonly IRolePermissionsRepository _rolePermissionsRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IPermissionsRepository _permissionRepository;
		public RolePermissionsService(IRolePermissionsRepository rolePermissionsRepository
			, IRoleRepository roleRepository
			, IPermissionsRepository permissionsRepository)
		{
			_rolePermissionsRepository = rolePermissionsRepository;
			_roleRepository = roleRepository;
			_permissionRepository = permissionsRepository;

		}

		public async Task<ApiResponse<bool>> AddRolePermission(RolePermissionRequestModel model)
		{
			var role = await _roleRepository.GetById(model.RoleId);
			if (role == null)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = "Role does not exist!"
				};
			}

			// Check if the permission exists
			var permission = await _permissionRepository.GetById(model.PermissionId);
			if (permission == null)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = "Permission with ID " + model.PermissionId + " does not exist!"
				};
			}

			// Check if the role already has this permission
			var rolePermissionExists = await _rolePermissionsRepository.GetRoleWithPermission(model.PermissionId);
			if (rolePermissionExists)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = "There is already a Role with this permission!"
				};
			}

			// Add the permission to the role
			await _rolePermissionsRepository.AddRolePermissions(model.RoleId, model.PermissionId);

			return new ApiResponse<bool>
			{
				IsError = false,
				Description = "Permissions added successfully!"
			};

		}
	}
}
