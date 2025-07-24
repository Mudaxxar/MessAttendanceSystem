using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Services.IService
{
    
    public interface IAttendanceService
    {
        Task<bool> MarAttendance(AttendanceRequestModel model);
        Task<PaginatedResponseModel<AttendanceResponseModel>> GetAttendanceAsync(PaginationParams dtParams);
        Task<AttendanceSettingsResponseModel> GetAttendanceSettingsAsync();
        Task<ApiResponse<string>> AddAttendanceSettingsAsync(AttendanceSettingsResponseModel model);
    }
}
