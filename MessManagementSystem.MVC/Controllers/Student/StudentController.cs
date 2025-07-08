using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MessManagementSystem.MVC.Controllers.Student
{
    public class StudentController : BaseController
    {
        private readonly IStudentClient _studentClient;
        public StudentController(IStudentClient studentClient)
        {
            _studentClient = studentClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _studentClient.GetStudent(Id);
            return View(result);
        }

        [HttpGet]
        public IActionResult MarkAttendance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequestModel dto)
        {
            var result = await _studentClient.MarkAttendance(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendance(int pageNumber = 0, int pageSize = 10, string search = null)
        {
            var userId = ConfigService.GetUserId();

            var result = await _studentClient.GetAsync(new PaginationParams
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search,
                UserId = userId

            });
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetAttendance([FromForm] DtParams dtParams)
        {
            var userId = ConfigService.GetUserId();
            var result = await _studentClient.GetAsync(new PaginationParams
            {
                PageNumber = dtParams.Start / 10,
                PageSize = dtParams.Length,
                Search = dtParams.Search.Value,
                SortOrder = dtParams.SortOrder,
                UserId = userId
            });

            var response = new DtResult<AttendanceResponseModel>()
            {
                Data = result.Records ?? new List<AttendanceResponseModel>(),
                Draw = dtParams.Draw,
                RecordsTotal = result.TotalRecords
            };
            return Ok(response);
        }


    }
}
