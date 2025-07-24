using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceClient _attendanceClient;
        public AttendanceController(IAttendanceClient attendanceClient)
        {
            _attendanceClient = attendanceClient;
        }
		[HttpGet]
		public async Task<IActionResult> GetAttendanceSettings()
		{
			var result = await _attendanceClient.GetAttendanceSettingsAsync();
			return View(result);
		}
		[HttpPost]
		public async Task<IActionResult> AddSettings(AttendanceSettingsResponseModel dto)
		{
			if (dto == null)
			{
				return BadRequest("No data found!");
			}
			var result = await _attendanceClient.AddAttendanceSettingsAsync(dto);
			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetAttendance(int pageNumber = 0, int pageSize = 10, string search = null)
		{
			var result = await _attendanceClient.GetAsync(new PaginationParams
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				Search = search,

			});
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetAttendance([FromForm] DtParams dtParams)
		{
			var result = await _attendanceClient.GetAsync(new PaginationParams
			{
				PageNumber = dtParams.Start / 10,
				PageSize = dtParams.Length,
				Search = dtParams.Search.Value,
				SortOrder = dtParams.SortOrder,
			});

			var response = new DtResult<AttendanceResponseModel>()
			{
				Data = result.Records ?? new List<AttendanceResponseModel>(),
				Draw = dtParams.Draw,
				RecordsTotal = result.TotalRecords
			};
			return Ok(response);
		}
	
        [HttpPost]
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequestModel dto)
        {
			if(dto == null)
			{
				return BadRequest("No data found!");
			}
            var result = await _attendanceClient.MarkAsync(dto);
            return Ok(result);
        }

    }
}
