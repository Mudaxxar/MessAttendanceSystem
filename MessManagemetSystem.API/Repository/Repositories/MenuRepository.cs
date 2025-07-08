using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MessManagemetSystem.API.Repository.Repositories
{
	public class MenuRepository : IMenuRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		public MenuRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> AddAsync(MenuEntity entity)
		{
			try
			{

		
			var repo = _unitOfWork.GetRepository<MenuEntity>();
			var existing = await repo.AnyAsync(x => x.DayofWeek == entity.DayofWeek && x.MealType == entity.MealType && x.MenuItems == entity.MenuItems && x.IsActive == true);

			if (!existing)
			{
				await repo.AddAsync(entity);
				await _unitOfWork.CommitAsync();
			}
            }
            catch (Exception ex)
            {

            }
            return true;
		}

		

		public async Task<PaginatedResponseModel<MenuEntity>> GetAsync(PaginationParams dtParams)
		{
			var repo = _unitOfWork.GetRepository<MenuEntity>();
			var query = repo.GetAll().Where(x=>x.IsActive == true);

			if (!string.IsNullOrEmpty(dtParams.Search))
			{

                query = query.Where(search =>
    search.MenuItems.ToLower().Contains(dtParams.Search)
    ||search.DayofWeek.ToString().ToLower().Contains(dtParams.Search)
);

            }
			var totalRecords = await query.CountAsync();
			var paginatedResult = await PaginatedHelper<MenuEntity>.GetPaginatedRecored(query, x => x.Id, dtParams);

			return new PaginatedResponseModel<MenuEntity>
			{
				TotalRecords = totalRecords,
				Records = paginatedResult,
				PaginationParam = dtParams
			};
		}
		public async Task<PaginatedResponseModel<MenuEntity>> GetAsync()
		{
			var repo = _unitOfWork.GetRepository<MenuEntity>();
			var result = await repo.GetAsync();
			return new PaginatedResponseModel<MenuEntity>
			{
				Records = result,
				TotalRecords = result.Count()
			};
		}

		public async Task<MenuEntity> GetByIdAsync(int Id)
		{
			var repo = _unitOfWork.GetRepository<MenuEntity>();
			return await repo.GetByIdAsync(Id);
		}

		

		public async Task<bool> UpdateAsync(int Id, MenuEntity model)
		{
            var repo = _unitOfWork.GetRepository<MenuEntity>();

            // Check for duplicate MenuItems in other records
            var duplicateExists = await repo
                .GetAll() // Assuming GetAll() returns IQueryable<MenuEntity>
                .AnyAsync(m => m.Id != Id && m.MenuItems == model.MenuItems);

            if (duplicateExists)
            {
                throw new InvalidOperationException("Duplicate menu items are not allowed.");
            }

            // Fetch the entity to update
            var entity = await repo.GetByIdAsync(Id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Menu not found.");
            }

            // Update fields
            entity.MenuItems = model.MenuItems;
            entity.UpdatedOn = DateTime.Now;
            // entity.UpdatedBy = model.UpdatedBy;

            // Save changes
            await repo.UpdateAsync(Id, entity);
            await _unitOfWork.CommitAsync();

            return true;
        }
		public async Task<List<MenuEntity>> GetWeeklyMenuAsync()
		{
			var repo = _unitOfWork.GetRepository<MenuEntity>();


			var menus = repo.GetAll(); // All 14 rows: 7 Lunch + 7 Dinner

		
			var totalRecords = await menus.CountAsync();
			return menus.ToList();

		}
	}
}
