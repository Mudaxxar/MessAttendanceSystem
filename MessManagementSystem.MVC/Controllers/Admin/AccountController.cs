using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.MVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace MessManagementSystem.MVC.Controllers.Admin
{

    public class AccountController : BaseController
    {
        private readonly IUserApiClient _userService;
        private readonly IRoleClient _roleService;
        public AccountController(IUserApiClient userService, IRoleClient roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        public IActionResult Login()

        {
            //if (ConfigService.IsUserLoggedIn())
            //    return RedirectToAction("Index", "Home");

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginRequestModel model)
        {
            var result = await _userService.LoginAsync(model);
            if (result.IsSuccess)
            {
                ConfigService.SetJwtToken(result.Token);
                // 🔍 Extract UserId from JWT and store in cookie
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(result.Token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                {
                    ConfigService.SetUserId(userId);
                }
                //ConfigService.SetUserId(result.Token.);
            }

            return Ok(result);
        }
        public ActionResult Logout()
        {
            ConfigService.Logout();

            // Prevent caching
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Register()
        {
            var result = await _roleService.GetAsync();
            ViewBag.Roles = result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequestModel model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(int pageNumber = 0, int pageSize = 10, string search = null)
        {
            var result = await _userService.GetUsers(new PaginationParams
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search
            });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetUsers([FromForm] DtParams dtParams)
        {
            var result = await _userService.GetUsers(new PaginationParams
            {
                PageNumber = dtParams.Start / 10,
                PageSize = dtParams.Length,
                Search = dtParams.Search.Value,
                SortOrder = dtParams.SortOrder
            });

            var response = new DtResult<UserResponseModel>()
            {
                Data = result.Records ?? new List<UserResponseModel>(),
                Draw = dtParams.Draw,
                RecordsTotal = result.TotalRecords
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int Id)
        {
            var result = await _userService.UserStatus(Id);
            return Ok(result);
        }

		public async Task<IActionResult> EditUser(int Id)
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


	}
}
