using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Repository.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		public PermissionsRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddAsync(PermissionEntity entity)
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			await repo.AddAsync(entity);
			await _unitOfWork.CommitAsync();
			return true;
		}
		public async Task<PaginatedResponseModel<PermissionEntity>> GetAsync(PaginationParams dtParams)
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			var query = repo.GetAll();

			if (!string.IsNullOrEmpty(dtParams.Search))
			{

				query = query
					.Where(search =>
										search.Name.ToLower().Contains(dtParams.Search));

			}
			var totalRecords = await query.CountAsync();
			var paginatedResult = await PaginatedHelper<PermissionEntity>.GetPaginatedRecored(query, x => x.Id, dtParams);

			return new PaginatedResponseModel<PermissionEntity>
			{
				TotalRecords = totalRecords,
				Records = paginatedResult,
				PaginationParam = dtParams
			};
		}
		public async Task<PaginatedResponseModel<PermissionEntity>> GetAsync()
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			var result = await repo.GetAsync();
			return new PaginatedResponseModel<PermissionEntity>
			{
				Records = result,
				TotalRecords = result.Count()
			};
		}
		public async Task<bool> UpdateAsync(int Id, PermissionEntity entity)
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			await repo.UpdateAsync(Id, entity);
			await _unitOfWork.CommitAsync();
			return true;
		}
		public async Task<PermissionEntity> GetById(int Id)
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			return await repo.GetByIdAsync(Id);
		}
		public async Task<bool> GetByName(string search)
		{
			var repo = _unitOfWork.GetRepository<PermissionEntity>();
			return await repo.AnyAsync(x => x.Name == search);
		}

	}
}
