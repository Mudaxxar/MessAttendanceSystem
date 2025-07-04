using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MessManagemetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("mark-attendance")]
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequestModel dto)
        {
            if (dto == null)
            {
                return BadRequest("Attendance data is required.");
            }
            dto.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _attendanceService.MarAttendance(dto);
            if (!result)
            {
                var failedResponse = new ApiResponse<bool>
                {
                    Description = "Failed!",
                    IsError = true,
                };
                return BadRequest(failedResponse);
            }
            var response = new ApiResponse<bool>
            {
                Description = "Success",
                IsError = false,
            };
            return Ok(response);

        }
    }
}
