using AutoMapper;
using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;

using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.Shared.Models.RequestModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MessManagemetSystem.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private IUserService _userService;
		private RoleManager<UserRoles> _roleManager;
		public UserManager<ApplicationUser> _manageUser;
		public IMapper _mapper;
		public AccountController(IUserService userService,
								 RoleManager<UserRoles> roleManager,
								IMapper mapper,
								UserManager<ApplicationUser> manageUser
								)
		{
			_userService = userService;
			_roleManager = roleManager;
			_mapper = mapper;
			_manageUser = manageUser;
		}

		// /api/account/register
		[HasPermission(AdminPermissions.Admin)]

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequestModel model)
		{
			UserRoles role = _roleManager.Roles.ToList().FirstOrDefault(r => r.Name == model.Role);

			if (ModelState.IsValid && role != null)
			{
				model.RoleId = role.Id;
				var result = await _userService.RegisterAsync(model);

				if (result.IsSuccess)
				{
					return Ok(result);
				}

				return BadRequest(result);
			}

			return BadRequest(new ApiResponse<bool>
			{
				IsError = true,
				Description = "role not found!"
			});
		}

		// /api/account/login
		[HttpPost("Login")]
		[AllowAnonymous]
		public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.LoginUserAsync(model);

				if (result.IsSuccess)
				{
					//await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
					return Ok(result);
				}

				return BadRequest(result);
			}

			return BadRequest("Some properties are not valid");
		}

		// /api/account/confirmemail?userid&token
		[HttpGet("ConfirmEmail")]
		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
				return NotFound();

			var result = await _userService.ConfirmEmailAsync(userId, token);

			if (result.IsSuccess)
			{
				return Ok(result);
				//return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
			}

			return BadRequest(result);
		}

		// api/account/forgetpassword
		[HttpPost("ForgetPassword")]
		public async Task<IActionResult> ForgetPassword(string email)
		{
			if (string.IsNullOrEmpty(email))
				return NotFound();

			var result = await _userService.ForgetPasswordAsync(email);

			if (result.IsSuccess)
				return Ok(result); // 200

			return BadRequest(result); // 400
		}

		// api/account/resetpassword
		[HttpPost("ResetPassword")]
		public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordRequestModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.ResetPasswordAsync(model);

				if (result.IsSuccess)
					return Ok(result);

				return BadRequest(result);
			}

			return BadRequest("Some properties are not valid");
		}

		[HttpPost("get-users")]
		[HasPermission(AdminPermissions.Admin)]
		public async Task<IActionResult> GetUsers([FromBody] PaginationParams paginationParams)
		{
			var result = await _userService.GetUsers(new PaginationParams
			{
				PageNumber = paginationParams.PageNumber,
				PageSize = paginationParams.PageSize,
				Search = paginationParams.Search
			});
			return Ok(result);
		}

		[HasPermission(AdminPermissions.Admin)]
		[HttpPost("user-status/{id}")]
		public async Task<IActionResult> ChangeStatus(int id)
		{
			var result = await _userService.UserStatus(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet("users-count")]
		public async Task<IActionResult> UsersCount()
		{
			var result = await _userService.UsersCount();

			return Ok(result);
		}

		[HttpGet("user/{Id}")]
		//[HasPermission(AdminPermissions.Student)]

		public async Task<IActionResult> GetStudent(int Id)
		{
			//string email = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var result = await _userService.GetByIdAsync(Id);

			return Ok(result);
		}

		[HttpPost("update-user/{Id}")]
		public async Task<IActionResult> UpdateUserAsync(int Id, UserRequestModel model)
		{

			var result = await _userService.UpdateAsync(Id, model);

			return Ok(result);
		}

	}
}

