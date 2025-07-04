using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers
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

	}
}
