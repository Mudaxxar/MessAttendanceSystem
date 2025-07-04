using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Services.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HashSet<string>> GetPermissionsAsync(int memberId)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            var roles = await repo.GetIncludeAsync(x => x.Id == memberId,
                                                    null, src =>
                                                    src.Include(x => x.Role)
                                                    .ThenInclude(x => x.RolePermissions)
                                                    .ThenInclude(x => x.Permission));

            return roles
                     .Select(x => x.Role)
                    .SelectMany(x => x.RolePermissions)
                    .Select(x => x.Permission.Name)
                    .ToHashSet();
        }
    }
}
