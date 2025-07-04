using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Entities;
using MessManagementSystem.Shared.Models;

namespace MessManagemetSystem.API.Repository.IRepositories
{
	public interface IMenuRepository
	{
		Task<PaginatedResponseModel<MenuEntity>> GetAsync(PaginationParams paginationParams);
		Task<PaginatedResponseModel<MenuEntity>> GetAsync();
		Task<bool> AddAsync(MenuEntity entity);
		Task<bool> UpdateAsync(int Id, MenuEntity entity);
		Task<MenuEntity> GetByIdAsync(int Id);
		Task<List<MenuEntity>> GetWeeklyMenuAsync();
	}
}