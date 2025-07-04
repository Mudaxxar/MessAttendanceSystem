using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Repository.IRepositories;

namespace MessManagemetSystem.API.Repository.Repositories
{
	public class RolePermissionsRepository : IRolePermissionsRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		public RolePermissionsRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddRolePermissions(int roleId, int permissionId)
		{
			var repo = _unitOfWork.GetRepository<RolePermissionEntity>();
			await repo.AddAsync(new RolePermissionEntity
			{
				RoleId = roleId,
				PermissionId = permissionId,
			});
			await _unitOfWork.CommitAsync();
			return true;
		}

		public async Task<bool> GetAny(int roleId, int permissionId)
		{
			var repo = _unitOfWork.GetRepository<RolePermissionEntity>();
			return await repo.AnyAsync(x => x.RoleId == roleId && x.PermissionId == permissionId);
		}
		public async Task<bool> GetRoleWithPermission(int permissionId)
		{
			var repo = _unitOfWork.GetRepository<RolePermissionEntity>();
			var rolePermission = await repo.FirstOrDefaultAsync(x => x.PermissionId == permissionId);
			if (rolePermission != null)
			{
				return true;
			}
			return false;
		}
		public async Task<IEnumerable<RolePermissionEntity>> GetRolePermissions()
		{
			var repo = _unitOfWork.GetRepository<RolePermissionEntity>();
			return await repo.GetAsync();

		}
	}
}
