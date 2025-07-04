using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
	public interface IExpenseHeadsService
	{
		Task<PaginatedResponseModel<ExpenseHeadsResponseModel>> GetAsync(PaginationParams paginationParams);
		Task<List<ExpenseHeadsResponseModel>> GetAsync();
		Task<ApiResponse<ExpenseHeadsResponseModel>> AddAsync(ExpenseHeadsRequestModel model);
		Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseHeadsRequestModel model);
		Task<ApiResponse<bool>> DeleteAsync(int id);
		Task<ApiResponse<ExpenseHeadsResponseModel>> GetByIdAsync(int id);
	}
}
