using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;

namespace MessManagementSystem.MVC.Services.IService
{
    public interface IUserApiClient
    {
        Task<UserManagerResponseModel> LoginAsync(LoginRequestModel requestModel);
        Task<UserManagerResponseModel> RegisterAsync(RegistrationRequestModel requestModel);
        Task<PaginatedResponseModel<UserResponseModel>> GetUsers(PaginationParams paginationParams);
        Task<UserManagerResponseModel> UserStatus(int Id);
        Task<UserResponseModel> GetUserAsync(int Id);
        Task<UserManagerResponse> UpdateAsync( int Id, UserRequestModel model);
        Task<double> UsersCount();
    }
}
