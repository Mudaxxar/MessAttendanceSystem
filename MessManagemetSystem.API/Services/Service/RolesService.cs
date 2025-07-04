using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.IRepositories;
using MessManagemetSystem.API.Services.IService;

namespace MessManagemetSystem.API.Services.Service
{
    public class RolesService : IRolesService
	{
		private readonly IRoleRepository _roleRepository;
		public RolesService(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}
		public async Task<ApiResponse<bool>> AddRole(RolesRequestModel model)
		{
			if (model == null)
			{
				throw new NullReferenceException("Model is null");
			}

			var existingRole = await _roleRepository.AnyAsync(model.Name);
			if (existingRole)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = $"{model.Name} already exists!",
				};
			}
			var result = await _roleRepository.AddRoleAsync(new UserRoles
			{
				Name = model.Name,
				NormalizedName = model.NormalizedName,
			});
			return new ApiResponse<bool>
			{
				IsError = false,
				Description = "Role add Successfully!"
			};

		}
		public async Task<ApiResponse<bool>> UpdateRole(int roleId, RolesRequestModel model)
		{
			var existingName = await _roleRepository.GetByIdAndName(roleId, model.Name);
			if (existingName is UserRoles)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = $"{model.Name} already exists!"
				};
			}

			var gerRole = await _roleRepository.GetById(roleId);
			gerRole.Name = model.Name;
			await _roleRepository.UpdateRoleAsync(gerRole);

			return new ApiResponse<bool>
			{
				Description = "Success",
				IsError = false,
			};
		}
		public async Task<ApiResponse<bool>> DeleteRole(int roleId)
		{
			var getRole = await _roleRepository.GetById(roleId);
			getRole.IsDeleted = true;
			await _roleRepository.UpdateRoleAsync(getRole);

			return new ApiResponse<bool>
			{
				Description = "Updated!",
				IsError = false,
			};
		}

		public async Task<UserRoles> GetRoleById(int id)
		{
			return await _roleRepository.GetById(id);
		}
		public async Task<PaginatedResponseModel<UserRoles>> GetRoles()
		{
			return await _roleRepository.GetAsync();

		}

		public async Task<PaginatedResponseModel<UserRoles>> GetRoles(PaginationParams paginationParams)
		{
			var result = await _roleRepository.GetAsync(paginationParams);

			return new PaginatedResponseModel<UserRoles>
			{
				TotalRecords = result.TotalRecords,
				Records = result.Records,
				PaginationParam = paginationParams
			};
		}

	}
}
