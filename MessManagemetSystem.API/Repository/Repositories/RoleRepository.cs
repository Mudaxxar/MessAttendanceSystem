using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		public RoleRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddRoleAsync(UserRoles model)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			await repo.AddAsync(model);
			_unitOfWork.Commit();
			return true;
		}

		public async Task<bool> UpdateRoleAsync(UserRoles userRoles)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			await repo.UpdateAsync(userRoles.Id, userRoles);
			_unitOfWork.Commit();
			return true;

		}

		public async Task<UserRoles> GetById(int Id)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			var result = repo.FirstOrDefaultIncludAsync(x => x.Id == Id, null,
				src => src.Include(rp => rp.RolePermissions));
			return await result;
		}
		public async Task<UserRoles> GetByIdAndName(int Id, string name)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			return await repo.FirstOrDefaultAsync(x => x.Id != Id && x.Name == name);
		}

		public async Task<PaginatedResponseModel<UserRoles>> GetAsync(PaginationParams dtParams)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			var query = repo.GetAll();

			if (!string.IsNullOrEmpty(dtParams.Search))
			{

				query = query
					.Where(search =>
										search.Name.ToLower().Contains(dtParams.Search));

			}
			var totalRecords = await query.CountAsync();
			var paginatedResult = await PaginatedHelper<UserRoles>.GetPaginatedRecored(query, x => x.Id, dtParams);

			return new PaginatedResponseModel<UserRoles>
			{
				TotalRecords = totalRecords,
				Records = paginatedResult,
				PaginationParam = dtParams
			};
		}
		public async Task<PaginatedResponseModel<UserRoles>> GetAsync()
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			var result = await repo.GetAsync();
			return new PaginatedResponseModel<UserRoles>
			{
				Records = result,
				TotalRecords = result.Count()
			};
		}

		public async Task<bool> AnyAsync(string name)
		{
			var repo = _unitOfWork.GetRepository<UserRoles>();
			return await repo.AnyAsync(x => x.Name == name);
		}
	}
}
