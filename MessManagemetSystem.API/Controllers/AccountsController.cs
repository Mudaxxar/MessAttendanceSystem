using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessManagemetSystem.API.Services.IService;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagemetSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountsService _accountsService;
        public AccountsController(IAccountsService accountsService)
        {
			_accountsService = accountsService;
        }
		[HttpPost("get-monthly-closing")]
		public async Task<PaginatedResponseModel<MonthlyClosingResponseModel>> GetMonthlyClosingAsync(PaginationParams paginationParams)
		{
			var result = await _accountsService.GetMonthlyClosingAsync(paginationParams);
			return result;
		}

    }
}