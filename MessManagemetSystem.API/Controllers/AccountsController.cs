using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessManagemetSystem.API.Services.IService;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Services.Service;
using MessManagemetSystem.API.Identity;

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

        [HttpPost("add-monthly-closing/{Id}")]
        public async Task<IActionResult> AddMonthlyClosing(int Id)
        {
            var result = await _accountsService.AddMonthlyClosingAsync(Id);
            return Ok(result);
        } 
        
        [HttpGet("get-statement/{Id}")]
        public async Task<IActionResult> GetStatement(int Id)
        {
            var result = await _accountsService.GetStatementAsync(Id);
            return Ok(result);
        }

      
        [HttpPost("get-students-statement")]
        public async Task<PaginatedResponseModel<StudentClosingResponse>> GetStatementByDate(StudentStatementRequestModel request)
        {
            var result = await _accountsService.GetStudentsStatementAsync(request);
            return result;
        }

    }
}