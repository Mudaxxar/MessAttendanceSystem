using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MarkAttendance(int pageNumber = 0, int pageSize = 10, string search = null)
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
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequestModel dto)
        {
            var result = await _attendanceClient.MarkAsync(dto);
            return Ok(result);
        }

    }
}
