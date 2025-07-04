using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Identity;
namespace MessManagemetSystem.API.Services.IService
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegistrationRequestModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginRequestModel model);
        Task<PaginatedResponseModel<UserResponseModel>> GetUsers(PaginationParams paginationParams);
        Task<UserResponseModel> GetUser(string Email);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);
        Task<UserManagerResponse> ForgetPasswordAsync(string email);
        Task<UserManagerResponse> UserStatus(int Id);
        Task<UserManagerResponse> UpdateAttendance(AttendanceRequestModel input);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordRequestModel model);
        Task<double> UsersCount();
    }
}
