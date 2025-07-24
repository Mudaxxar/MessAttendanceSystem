using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Services.IService;
using MessManagemetSystem.API.Services.Service;
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
            dto.UserEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var studentRole = User.IsInRole("student");
            var timeSetting = await _attendanceService.GetAttendanceSettingsAsync();
            TimeSpan dbEndTime;
            if (timeSetting is not null)
            {
                dbEndTime = timeSetting.EndTime;
            }
            else
            {
                dbEndTime = TimeSpan.Parse("23:59");
            }
            // ✅ Get current server time
            var currentTime = DateTime.Now.TimeOfDay;

            // ✅ Restrict non-admin users after end time
            if (studentRole && currentTime > dbEndTime)
            {
                var expiredResponse = new ApiResponse<bool>
                {
                    Description = "⛔ Attendance marking is closed for today.",
                    IsError = true,
                };
                return BadRequest(expiredResponse);
            }
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

        [HttpPost("get-attendance")]
        public async Task<IActionResult> GetAttendance([FromBody] PaginationParams paginationParams)
        {
            var result = await _attendanceService.GetAttendanceAsync(new PaginationParams
            {
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                Search = paginationParams.Search,
                UserId = paginationParams.UserId
            });
            return Ok(result);
        }

        [HttpGet("get-settings")]
        public async Task<IActionResult> GetSettingsAsync()
        {

            var result = await _attendanceService.GetAttendanceSettingsAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse<AttendanceSettingsResponseModel>
                {
                    Description = "Attendance settings not found.",
                    IsError = true,
                    Data = new AttendanceSettingsResponseModel
                    {

                    }
                });
            }
            return Ok(new ApiResponse<AttendanceSettingsResponseModel>
            {
                Data = result,
                Description = "Success",
                IsError = false
            });
        }

		[HttpPost("save-settings")]
		public async Task<IActionResult> SaveSettingsAsync([FromBody] AttendanceSettingsResponseModel model)
		{
			if (model == null)
			{
				return BadRequest(new ApiResponse<bool>
				{
					Description = "Attendance settings data is required.",
					IsError = true
				});
			}

			var result = await _attendanceService.AddAttendanceSettingsAsync(model);
			if (result.IsError)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
	}
}
