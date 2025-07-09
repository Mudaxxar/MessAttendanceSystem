using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.IClients
{
    public interface IAccounsClient
    {
        public Task<PaginatedResponseModel<MonthlyClosingResponseModel>> GetMonthlyClosingAsync(PaginationParams paginationParams);
	}
}
