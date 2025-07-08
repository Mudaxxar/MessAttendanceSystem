using MessManagementSystem.MVC.DataTableModels;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.MVC.Clients.IClients;

namespace MessManagementSystem.MVC.Controllers.Admin
{

    public class ExpenseHeadsController : BaseController
    {
        private readonly IExpenseHeadsClient _expenseHeadClient;

        public ExpenseHeadsController(IExpenseHeadsClient ExpenseHeadservice)
        {
            _expenseHeadClient = ExpenseHeadservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenseHeads(int pageNumber = 1, int pageSize = 10, string search = null)
        {
            var result = await _expenseHeadClient.GetAsync(new PaginationParams
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search
            });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetExpenseHeads([FromForm] DtParams dtParams)
        {
            var result = await _expenseHeadClient.GetAsync(new PaginationParams
            {
                PageNumber = dtParams.Start / 10,
                PageSize = dtParams.Length,
                Search = dtParams.Search.Value,
                SortOrder = dtParams.SortOrder
            });

            var response = new DtResult<ExpenseHeadsResponseModel>()
            {
                Data = result.Records ?? new List<ExpenseHeadsResponseModel>(),
                Draw = dtParams.Draw,
                RecordsTotal = result.TotalRecords
            };
            return Ok(response);
        }

        public IActionResult Add()
        {
            return View(new ExpenseHeadsRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenseHeads(ExpenseHeadsRequestModel model)
        {
            var result = await _expenseHeadClient.AddAsync(model);
            return Ok(result);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _expenseHeadClient.GetByIdAsync(Id);

            return View(new ExpenseHeadsRequestModel
            {
                Name = result.Data.Name,
                Id = result.Data.Id

            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExpenseHeads(int id, ExpenseHeadsRequestModel model)
        {
            var result = await _expenseHeadClient.UpdateAsync(id, model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpenseHeads(int id)
        {
            var result = await _expenseHeadClient.DeleteAsync(id);
            return Ok(result);
        }

    }
}
