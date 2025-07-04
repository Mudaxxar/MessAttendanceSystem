using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.Shared.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MessManagemetSystem.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	//[HasPermission(AdminPermissions.Admin)]
	//[Authorize]
	[ProducesResponseType(401)]
	public class MenuController : ControllerBase
	{
		private readonly IMenuService _MenuServices;
		private readonly ILogger<MenuController> _Logger;
		public MenuController(IMenuService MenuService,
				ILogger<MenuController> logger)
		{
			_MenuServices = MenuService;
			_Logger = logger;
		}

		[HttpPost("get-Menus")]
		public async Task<IActionResult> GetMenus([FromBody] PaginationParams paginationParams)
		{
			var Menu = await _MenuServices.GetAsync(new PaginationParams
			{
				PageNumber = paginationParams.PageNumber,
				PageSize = paginationParams.PageSize,
				Search = paginationParams.Search,

			});
			_Logger.LogInformation("get Menus", "Menus");
			return Ok(Menu);
		}

		[HttpGet("get-all-Menus")]
		public async Task<IActionResult> GetMenus()
		{
			var result = await _MenuServices.GetAsync();
			return Ok(result);
		}

		[HttpPost("add-Menu")]
		public async Task<IActionResult> AddMenu([FromBody] MenuRequestModel model)
		{
			var result = await _MenuServices.AddAsync(model);

			if (!result.IsError)
			{
				return StatusCode(StatusCodes.Status201Created, result);
			}
			return BadRequest(result);
		}

		[HttpPost("update-Menu/{Id:int}")]
		public async Task<IActionResult> UpdateMenu(int Id, [FromBody] MenuRequestModel model)
		{
			var result = await _MenuServices.UpdateAsync(Id, model);

			if (result)
			{

				return StatusCode(200, "Successfully Updated");
			}

			return NotFound("Menu not found or update failed.");
		}

		[HttpPost("delete-Menu/{Id:int}")]
		public async Task<IActionResult> DeleteMenu(int Id)
		{
			var result = await _MenuServices.DeleteAsync(Id);

			if (result)
			{
				return Ok("Menu deleted successfully.");
			}

			return NotFound("Menu not found or delete failed.");
		}

		[HttpGet("getById/{Id:int}")]
		public async Task<IActionResult> GetMenuById(int Id)
		{
			var Menu = await _MenuServices.GetByIdAsync(Id);

			if (Menu != null)
			{
				return Ok(Menu);
			}

			return NotFound("Menu not found.");
		}

		[HttpGet("weekly")]
		public async Task<IActionResult> GetWeeklyMenu()
		{
			var result = await  _MenuServices.GetWeeklyMenuAsync();

			return Ok(result);
		}


	}
}
