using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers
{
	public class MenuController : BaseController
    {
		private readonly IMenuClient _MenuService;
		public MenuController(IMenuClient MenuService)
		{
			_MenuService = MenuService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMenus(int pageNumber = 0, int pageSize = 10, string search = null)
		{
			var result = await _MenuService.GetAsync(new PaginationParams
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				Search = search,
			});
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetMenus([FromForm] DtParams dtParams)
		{
			var result = await _MenuService.GetAsync(new PaginationParams
			{
				PageNumber = dtParams.Start / 10,
				PageSize = dtParams.Length,
				Search = dtParams.Search.Value,
				SortOrder = dtParams.SortOrder
			});

			var response = new DtResult<MenuResponseModel>()
			{
				Data = result.Records ?? new List<MenuResponseModel>(),
				Draw = dtParams.Draw,
				RecordsTotal = result.TotalRecords
			};
			return Ok(response);
		}

		public IActionResult Add()
		{
			return View(new MenuRequestModel());
		}

		public async Task<IActionResult> Edit(int Id)
		{
			var result = await _MenuService.GetByIdAsync(Id);

			return result != null ? View(result) : NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddMenu(MenuRequestModel model)
		{
			var result = await _MenuService.AddAsync(model);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateMenu(int Id, MenuRequestModel model)
		{
			var result = await _MenuService.UpdateAsync(Id, model);
			TempData["success"] = "Menu Updated!";
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteMenu(int Id)
		{
			var result = await _MenuService.DeleteAsync(Id);
			return Ok(result);
		}


	}
}
