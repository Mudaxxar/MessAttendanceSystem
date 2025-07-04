using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;

namespace MessManagementSystem.MVC.Clients.IClients
{
	public interface IExpenseHeadsClient
	{
		Task<PaginatedResponseModel<ExpenseHeadsResponseModel>> GetAsync(PaginationParams paginationParams);
		Task<List<ExpenseHeadsResponseModel>> GetAllAsync();
		Task<ApiResponse<ExpenseHeadsResponseModel>> AddAsync(ExpenseHeadsRequestModel model);
		Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseHeadsRequestModel model);
		Task<ApiResponse<bool>> DeleteAsync(int id);
		Task<ApiResponse<ExpenseHeadsResponseModel>> GetByIdAsync(int id);
	}
}
