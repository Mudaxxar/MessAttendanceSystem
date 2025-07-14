using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;

namespace MessManagementSystem.MVC.Clients.IClients
{
    public interface IAttendanceClient
    {
        Task<ApiResponse<string>> MarkAsync(AttendanceRequestModel input);
        Task<PaginatedResponseModel<AttendanceResponseModel>> GetAsync(PaginationParams paginationParams);
    }
}
