
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace MessManagemetSystem.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	//[HasPermission(AdminPermissions.Admin)]

	public class RolesController : ControllerBase
	{
		private readonly IRolesService _roleService;
		private readonly IRolePermissionsService _rolePermissions;

		public RolesController(IRolesService rolesService, IRolePermissionsService rolePermissions)
		{
			_roleService = rolesService;
			_rolePermissions = rolePermissions;
		}
		[HttpPost("Create")]
		public async Task<IActionResult> CreateRoles([FromBody] RolesRequestModel model)
		{
			var result = await _roleService.AddRole(model);

			if (!result.IsError)
			{
				return Ok(result); // Status Code: 200 
			}

			return BadRequest(result);
		}

		[HttpPost("update-Role/{id:int}")]
		public async Task<IActionResult> UpdateRole(int id, [FromBody] RolesRequestModel updatedModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _roleService.UpdateRole(id, updatedModel);

				if (!result.IsError)
				{

					return Ok(result); // Status Code: 200
				}

				return BadRequest(result);
			}

			return BadRequest("Some properties are not valid"); // Status code: 400
		}

		[HttpPost("delete-role/{id:int}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			var result = await _roleService.DeleteRole(id);

			if (!result.IsError)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getById/{Id:int}")]
		public async Task<IActionResult> GetRolesById(int Id)
		{
			var role = await _roleService.GetRoleById(Id);

			if (role != null)
			{
				return Ok(role);
			}

			return NotFound(new { error = "no record found!" });
		}

		[HttpPost("get-roles")]
		public async Task<IActionResult> GetUserRoles([FromBody] PaginationParams paginationParams)
		{
			var result = await _roleService.GetRoles(new PaginationParams
			{
				PageNumber = paginationParams.PageNumber,
				PageSize = paginationParams.PageSize,
				Search = paginationParams.Search
			});
			return Ok(result);
		}

		[HttpGet("get-all-roles")]
		public async Task<IActionResult> GetUserRoles()
		{
			var result = await _roleService.GetRoles();
			return Ok(result);
		}
		[HttpPost("add-permission")]
		public async Task<IActionResult> AddPermission(RolePermissionRequestModel model)
		{
			var result = await _rolePermissions.AddRolePermission(model);

			if (!result.IsError)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
