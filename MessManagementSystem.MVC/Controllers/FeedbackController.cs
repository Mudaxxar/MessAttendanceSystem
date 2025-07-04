using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IStudentClient _studentClient;
        public FeedbackController(IStudentClient studentClient )
        {
            _studentClient = studentClient;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var result = await _studentClient.GetFeedbacks();
            return View(result);
        }  
        [HttpGet]
        public IActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackRequestModel dto)
        {
            var result = await _studentClient.CreateFeedback(dto);
            return Ok(result);
        }
    }
}
