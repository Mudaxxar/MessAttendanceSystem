using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;

namespace MessManagemetSystem.API.Repository.IRepositories
{
    public interface IPermissionsRepository
	{
		Task<PaginatedResponseModel<PermissionEntity>> GetAsync(PaginationParams paginationParams);
		Task<PaginatedResponseModel<PermissionEntity>> GetAsync();
		Task<bool> AddAsync(PermissionEntity entity);
		Task<bool> UpdateAsync(int Id, PermissionEntity entity);
		Task<PermissionEntity> GetById(int Id);
		Task<bool> GetByName(string search);

	}
}
