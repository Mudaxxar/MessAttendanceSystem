using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IAccountsService
    {
        Task<ApiResponse<bool>> AddMonthlyClosingAsync(int Id);
        Task<PaginatedResponseModel<MonthlyClosingResponseModel>> GetMonthlyClosingAsync(PaginationParams pParams);
        Task<List<AccountsResponseModel>> GetStatementAsync(int UserId);
        Task<PaginatedResponseModel<StudentClosingResponse>> GetStudentsStatementAsync(StudentStatementRequestModel pParams);


    }
}
