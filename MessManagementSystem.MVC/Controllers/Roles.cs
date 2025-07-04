using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.DataTableModels;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.MVC.Configuration;

namespace MessManagementSystem.MVC.Controllers
{
	public class RolesController : BaseController
    {
		private readonly IRoleClient _roleService;

		public RolesController(IRoleClient roleService)
		{
			_roleService = roleService;
		}

		[HttpGet]
		public async Task<IActionResult> GetRoles(int pageNumber = 0, int pageSize = 10, string search = null)
		{
			var result = await _roleService.GetAsync(new PaginationParams
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				Search = search
			});
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetRoles([FromForm] DtParams dtParams)
		{
			var result = await _roleService.GetAsync(new PaginationParams
			{
				PageNumber = dtParams.Start / 10,
				PageSize = dtParams.Length,
				Search = dtParams.Search.Value,
				SortOrder = dtParams.SortOrder
			});

			var response = new DtResult<RoleResponseModel>()
			{
				Data = result.Records ?? new List<RoleResponseModel>(),
				Draw = dtParams.Draw,
				RecordsTotal = result.TotalRecords
			};
			return Ok(response);
		}

		public IActionResult Add()
		{
			return View(new RolesRequestModel());
		}

		[HttpPost]
		public async Task<IActionResult> AddRole(RolesRequestModel model)
		{
			var result = await _roleService.AddAsync(model);
			return Ok(result);
		}
		public async Task<IActionResult> Edit(int Id)
		{
			var result = await _roleService.GetByIdAsync(Id);
			var permissionIds = result.RolePermissions.Select(rp => rp.PermissionId).ToList();

			return View(new RolesRequestModel
			{
				Id = result.Id,
				Name = result.Name,
				Permissions = permissionIds
			});
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(string id, RolesRequestModel model)
		{
			var result = await _roleService.UpdateAsync(id, model);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteRole(string id)
		{
			var result = await _roleService.DeleteAsync(id);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> AddPermission(RolePermissionRequestModel model)
		{
			var result = await _roleService.AddPermission(model);
			return Ok(result);
		}
	}
}
