using MessManagementSystem.MVC.Clients.Client;
using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers.Admin
{
	public class AccountsController : Controller
	{
		private readonly IAccounsClient _accountsClient;
        public AccountsController(IAccounsClient accounsClient)
        {
			_accountsClient = accounsClient;
		}
		[HttpGet]
		public async Task<IActionResult> GetMonthlyClosing(int pageNumber = 1, int pageSize = 10, string search = null)
		{
			var result = await _accountsClient.GetMonthlyClosingAsync(new PaginationParams
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				Search = search
			});
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetMonthlyClosing([FromForm] DtParams dtParams)
		{
			var result = await _accountsClient.GetMonthlyClosingAsync(new PaginationParams
			{
				PageNumber = dtParams.Start / 10,
				PageSize = dtParams.Length,
				Search = dtParams.Search.Value,
				SortOrder = dtParams.SortOrder
			});

			var response = new DtResult<MonthlyClosingResponseModel>()
			{
				Data = result.Records ?? new List<MonthlyClosingResponseModel>(),
				Draw = dtParams.Draw,
				RecordsTotal = result.TotalRecords
			};
			return Ok(response);
		}

		[HttpGet]
        public async Task<IActionResult> GetStudentsStatement(int pageNumber = 1, int pageSize = 10, string search = null)
        {
            var result = await _accountsClient.GetStudentStatementAsync(new StudentStatementRequestModel
            {
                PaginationParams = new PaginationParams
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Search = search
                },
                Date = DateTime.Now.Date
            }
          );
            return View(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> GetStudentsStatement([FromForm] DtParams dtParams, [FromForm] DateTime date)
        {
            var result = await _accountsClient.GetStudentStatementAsync(new StudentStatementRequestModel
            {
                PaginationParams = new PaginationParams
                {
                    PageNumber = dtParams.Start / 10,
                    PageSize = dtParams.Length,
                    Search = dtParams.Search.Value,
                    SortOrder = dtParams.SortOrder
                },
               Date = date
            });

            var response = new DtResult<StudentClosingResponse>()
            {
                Data = result.Records ?? new List<StudentClosingResponse>(),
                Draw = dtParams.Draw,
                RecordsTotal = result.TotalRecords
            };
            return Ok(response);
        }
    }
}
