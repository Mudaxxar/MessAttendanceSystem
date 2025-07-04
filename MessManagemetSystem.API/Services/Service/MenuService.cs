using AutoMapper;
using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.Entities;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Repository.IRepositories;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Services.Service
{
	public class MenuService : IMenuService
	{
		private readonly IMapper _mapper;
		private readonly IMenuRepository _MenuRepository;
		public MenuService(IMapper mapper
							 , IMenuRepository MenuRepository)
		{
			_mapper = mapper;
			_MenuRepository = MenuRepository;
		}
		public async Task<ApiResponse<bool>> AddAsync(MenuRequestModel model)
		{
			
			await _MenuRepository.AddAsync(new MenuEntity
			{
				DayofWeek = model.DayOfWeek,
				MealType = model.MealType,
				MenuItems =model.MenuItems,
			});
			return new ApiResponse<bool>
			{
				IsError = false,
				Description = "Successfully"
			};
		}
		//Update Menu
		public async Task<bool> UpdateAsync(int Id, MenuRequestModel model)
		{
			var mapperObject = await _MenuRepository.GetByIdAsync(Id);
			mapperObject.MenuItems = model.MenuItems;
			mapperObject.UpdatedOn = DateTime.Now;
			//mapperObject.UpdatedBy = model.UpdatedBy;
			await _MenuRepository.UpdateAsync(Id, mapperObject);
			return true;
		}
		//Get Menu by Id
		public async Task<MenuResponseModel> GetByIdAsync(int MenuId)
		{

			var Menu = await _MenuRepository.GetByIdAsync(MenuId);

			if (Menu is null)
			{
				return null;
			}
			var responseModel = _mapper.Map<MenuResponseModel>(Menu);

			return responseModel;
		}

		//Delete Menu
		public async Task<bool> DeleteAsync(int MenuId)
		{

			var Menu = await _MenuRepository.GetByIdAsync(MenuId);
			if (Menu is null)
			{
				return false;
			}
			Menu.IsActive = false;

			await _MenuRepository.UpdateAsync(MenuId, Menu);
			return true;
		}

		public async Task<PaginatedResponseModel<MenuResponseModel>> GetAsync(PaginationParams paginationParams)
		{
			var result = await _MenuRepository.GetAsync(paginationParams);
			var mapperObject = _mapper.Map<IEnumerable<MenuResponseModel>>(result.Records);
			return new PaginatedResponseModel<MenuResponseModel>
			{
				TotalRecords = result.TotalRecords,
				Records = mapperObject,
				PaginationParam = paginationParams
			};
		}
		public async Task<PaginatedResponseModel<MenuResponseModel>> GetAsync()
		{
			var result = await _MenuRepository.GetAsync();
			var mapperObject = _mapper.Map<IEnumerable<MenuResponseModel>>(result.Records);
			return new PaginatedResponseModel<MenuResponseModel>
			{
				TotalRecords = result.TotalRecords,
				Records = mapperObject,
			};

		}

		public async Task<List<WeeklyMenuViewModel>> GetWeeklyMenuAsync()
		{
			var menus = await _MenuRepository.GetWeeklyMenuAsync();

            var result = menus
      .GroupBy(m => m.MealType)
      .Select(g => new WeeklyMenuViewModel
      {
          MealType = g.Key,
          DailyItems = g
              .GroupBy(m => m.DayofWeek.ToString())
              .ToDictionary(
                  mg => mg.Key,
                  mg => mg.First().MenuItems // pick the first if duplicates exist
              )
      }).ToList();

            return result;
		}
	}
}
