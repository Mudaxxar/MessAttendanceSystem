using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    public interface IAccountsService
    {
        Task<PaginatedResponseModel<ClosingResponseModel>> GetClosingAsync(PaginationParams pParams);
    }
}
