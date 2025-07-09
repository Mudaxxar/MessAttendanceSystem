using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.MVC.Controllers.Admin
{

    public class ExpenseController : BaseController
    {
        private readonly IExpenseClient _expenseClient;
        private readonly IExpenseHeadsClient _expenseHeadClient;

        public ExpenseController(IExpenseClient Expenseervice, IExpenseHeadsClient expenseHeadClient)
        {
            _expenseClient = Expenseervice;
            _expenseHeadClient = expenseHeadClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpense(int pageNumber = 1, int pageSize = 10, string search = null)
        {
            var result = await _expenseClient.GetAsync(new PaginationParams
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search
            });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetExpense([FromForm] DtParams dtParams)
        {
            var result = await _expenseClient.GetAsync(new PaginationParams
            {
                PageNumber = dtParams.Start / 10,
                PageSize = dtParams.Length,
                Search = dtParams.Search.Value,
                SortOrder = dtParams.SortOrder
            });

            var response = new DtResult<ExpenseResponseModel>()
            {
                Data = result.Records ?? new List<ExpenseResponseModel>(),
                Draw = dtParams.Draw,
                RecordsTotal = result.TotalRecords
            };
            return Ok(response);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.ExpenseHeads = await _expenseHeadClient.GetAllAsync();
            return View(new ExpenseRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseRequestModel model)
        {
            var result = await _expenseClient.AddAsync(model);
            return Ok(result);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _expenseClient.GetByIdAsync(Id);

            return View(new ExpenseRequestModel
            {
                ExpenseHeadId = result.Data.ExpenseHeadId,
                Id = result.Data.Id

            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExpense(int id, ExpenseRequestModel model)
        {
            var result = await _expenseClient.UpdateAsync(id, model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var result = await _expenseClient.DeleteAsync(id);
            return Ok(result);
        }

        //Monthly Expenses
        [HttpGet]
        public async Task<IActionResult> GetMonthlyExpense(int pageNumber = 1, int pageSize = 10, string search = null)
        {
            var result = await _expenseClient.GetMonthlyAsync(new PaginationParams
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search
            });
            return View(result);
        }
        public async Task<IActionResult> AddMonthly()
        {
            ViewBag.ExpenseHeads = await _expenseHeadClient.GetAllAsync();
            return View(new ExpenseRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddMonthlyExpense(ExpenseRequestModel model)
        {
            
            var result = await _expenseClient.AddMonthlyAsync(model);
            return Ok(result);
        }
        public async Task<IActionResult> EditMonthlyExpense(int Id)
        {
            var result = await _expenseClient.GetByIdAsync(Id);

            return View(new ExpenseRequestModel
            {
                ExpenseHeadId = result.Data.ExpenseHeadId,
                Id = result.Data.Id

            });
        }

        public async Task<IActionResult> MonthlyClosing()
        {
            ViewBag.ExpenseHeads = await _expenseHeadClient.GetAllAsync();
            return View(new ExpenseRequestModel());
        }
        [HttpPost]
        public async Task<IActionResult> MonthlyClosing(int Id)
        {
            var result = await _expenseClient.AddMonthlyClosingAsync(Id);
			return Ok(result);
        }
    }
}
