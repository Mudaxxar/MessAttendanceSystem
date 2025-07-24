using AutoMapper;
using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.IRepositories;
using MessManagemetSystem.API.Services.IService;
using MessManagemetSystem.API.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Services.Service
{
    public class PermissionsService : IPermissionsService
	{
		private readonly IPermissionsRepository _permissionsRepository;
		private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PermissionsService(IPermissionsRepository permissionsRepository,
			IMapper mapper
            , IUnitOfWork unitOfWork)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<HashSet<string>> GetPermissionsAsync(int memberId)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            var roles = await repo.GetIncludeAsync(x => x.Id == memberId,
                                                    null, src =>
                                                    src.Include(x => x.Role)
                                                    .ThenInclude(x => x.RolePermissions)
                                                    .ThenInclude(x => x.Permission));

            return roles
                     .Select(x => x.Role)
                    .SelectMany(x => x.RolePermissions)
                    .Select(x => x.Permission.Name)
                    .ToHashSet();
        }
        public async Task<ApiResponse<bool>> AddAsync(PermissionRequestModel model)
		{
			var existingPermission = await _permissionsRepository.GetByName(model.Name);
			if (existingPermission)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = $"Name {model.Name} already exists!"
				};
			}
			await _permissionsRepository.AddAsync(new PermissionEntity
			{
				Name = model.Name,
			});
			return new ApiResponse<bool>
			{
				IsError = false,
				Description = "Permission added successfully!"
			};
		}

		public async Task<bool> DeleteAsync(int Id)
		{
			var permission = await _permissionsRepository.GetById(Id);
			permission.IsActive = false;
			await _permissionsRepository.UpdateAsync(Id, permission);
			return true;
		}

		public async Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync(PaginationParams paginationParams)
		{
			var permission = await _permissionsRepository.GetAsync(paginationParams);
			var map = _mapper.Map<IEnumerable<PermissionResponseModel>>(permission.Records);
			return new PaginatedResponseModel<PermissionResponseModel>
			{
				TotalRecords = permission.TotalRecords,
				Records = map,
				PaginationParam = paginationParams
			};
		}

		public async Task<PaginatedResponseModel<PermissionResponseModel>> GetAsync()
		{
			var result = await _permissionsRepository.GetAsync();
			var map = _mapper.Map<IEnumerable<PermissionResponseModel>>(result.Records);
			return new PaginatedResponseModel<PermissionResponseModel>
			{
				TotalRecords = result.TotalRecords,
				Records = map,
			};
		}

		public async Task<PermissionResponseModel> GetByIdAsync(int Id)
		{
			var permission = await _permissionsRepository.GetById(Id);
			var response = new PermissionResponseModel
			{
				Id = permission.Id,
				Name = permission.Name,
			};
			return response;
		}

		public async Task<ApiResponse<bool>> UpdateAsync(int Id, PermissionRequestModel model)
		{
			var existingName = await _permissionsRepository.GetByName(model.Name);
			if (existingName)
			{
				return new ApiResponse<bool>
				{
					IsError = true,
					Description = $"{model.Name} already exists!"
				};
			}

			var permission = await _permissionsRepository.GetById(Id);
			permission.Name = model.Name;
			await _permissionsRepository.UpdateAsync(Id, permission);

			return new ApiResponse<bool>
			{
				IsError = false,
				Description = "Success"
			};
		}
	}
}
