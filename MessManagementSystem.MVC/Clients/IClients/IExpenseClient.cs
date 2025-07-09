using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;

namespace MessManagementSystem.MVC.Clients.IClients
{
    public interface IExpenseClient
    {
        Task<PaginatedResponseModel<ExpenseResponseModel>> GetAsync(PaginationParams paginationParams);
        Task<PaginatedResponseModel<ExpenseResponseModel>> GetMonthlyAsync(PaginationParams paginationParams);
        Task<ApiResponse<ExpenseResponseModel>> AddAsync(ExpenseRequestModel model);
        Task<ApiResponse<ExpenseResponseModel>> AddMonthlyAsync(ExpenseRequestModel model);
        Task<ApiResponse<bool>> AddMonthlyClosingAsync(int Id);
        Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseRequestModel model);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<ExpenseResponseModel>> GetByIdAsync(int id);
    }
}
