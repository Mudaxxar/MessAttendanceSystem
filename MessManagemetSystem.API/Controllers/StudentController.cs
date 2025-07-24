using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagemetSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
        private readonly IUserService _userService;
        public StudentController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user/{Id}")]
        public async Task<IActionResult> GetStudent(int Id)
        {
            //string email = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _userService.GetByIdAsync(Id);

            return Ok(result);
        }
    }
}
