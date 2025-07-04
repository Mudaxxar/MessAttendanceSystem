using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;


namespace MessManagementSystem.MVC.Clients.IClients
{
	public interface IMenuClient
	{
		Task<ApiResponse<string>> AddAsync(MenuRequestModel MenuRequestModel);
		Task<string> UpdateAsync(int Id, MenuRequestModel MenuRequestModel);
		Task<string> DeleteAsync(int Id);
		Task<PaginatedResponseModel<MenuResponseModel>> GetAsync(PaginationParams paginationParams);
		Task<IEnumerable<MenuResponseModel>> GetAsync();
		Task<MenuResponseModel> GetByIdAsync(int Id);
        Task<List<WeeklyMenuViewModel>> GetWeeklyMenuAsync();
    }
}
