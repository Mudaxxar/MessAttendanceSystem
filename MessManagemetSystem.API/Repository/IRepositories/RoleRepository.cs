using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Identity;

namespace MessManagemetSystem.API.Repository.IRepositories
{
    public interface IRoleRepository
    {
        Task<UserRoles> GetById(int Id);
        Task<UserRoles> GetByIdAndName(int Id, string name);
        Task<bool> AddRoleAsync(UserRoles model);
        Task<bool> UpdateRoleAsync(UserRoles Id);
        Task<bool> AnyAsync(string name);

        Task<PaginatedResponseModel<UserRoles>> GetAsync(PaginationParams paginationParams);
        Task<PaginatedResponseModel<UserRoles>> GetAsync();
    }
}
