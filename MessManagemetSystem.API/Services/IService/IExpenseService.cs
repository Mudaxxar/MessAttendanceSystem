using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IExpenseService
    {
        Task<PaginatedResponseModel<ExpenseResponseModel>> GetAsync(PaginationParams paginationParams);
        Task<PaginatedResponseModel<ExpenseResponseModel>> GetMonthlyAsync(PaginationParams paginationParams);
        Task<ApiResponse<ExpenseResponseModel>> AddAsync(ExpenseRequestModel model);
        Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseRequestModel model);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<ExpenseResponseModel>> GetByIdAsync(int id);
    }
}
