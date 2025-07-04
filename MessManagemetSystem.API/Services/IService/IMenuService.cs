using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;

using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IMenuService
	{
		Task<PaginatedResponseModel<MenuResponseModel>> GetAsync(PaginationParams paginationParams);
		Task<PaginatedResponseModel<MenuResponseModel>> GetAsync();
		Task<ApiResponse<bool>> AddAsync(MenuRequestModel model);
		Task<bool> UpdateAsync(int Id, MenuRequestModel model);
		Task<MenuResponseModel> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);
		Task<List<WeeklyMenuViewModel>> GetWeeklyMenuAsync();
	}
}
