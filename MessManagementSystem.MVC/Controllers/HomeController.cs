using MessManagementSystem.MVC.Clients.Client;
using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MessManagementSystem.MVC.Controllers
{
    public class HomeController : BaseController
    {
		private readonly ILogger<HomeController> _logger;
		private readonly IMenuClient _menuClient;
		private readonly IUserApiClient _userApiClient;
		private readonly ISummaryClient _summaryClient;
		public HomeController(ILogger<HomeController> logger
			, IMenuClient menuClient
			, IUserApiClient userApiClient
			, ISummaryClient summaryClient)
		{
			_logger = logger;
			_menuClient = menuClient;
			_userApiClient = userApiClient;
			_summaryClient = summaryClient;
		}

		public async Task<IActionResult> Index()
		{
            if (!ConfigService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }
            var result = await _menuClient.GetWeeklyMenuAsync();
            ViewBag.Summary = await _summaryClient.GetSummaryAsync(ConfigService.GetUserId(), DateTime.Now);
			
			return View(result);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
