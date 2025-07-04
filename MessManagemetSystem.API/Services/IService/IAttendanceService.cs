using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagemetSystem.API.Services.IService
{
    
    public interface IAttendanceService
    {
        Task<bool> MarAttendance(AttendanceRequestModel model);
    }
}
