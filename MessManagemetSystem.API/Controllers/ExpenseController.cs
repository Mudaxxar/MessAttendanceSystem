using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagemetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseervice;
        public ExpenseController(IExpenseService expenseService)
        { _expenseervice = expenseService; }


        [HttpPost("get-expenses")]
        public async Task<IActionResult> GetAsync([FromBody] PaginationParams paginationParams)
        {
            var expense = await _expenseervice.GetAsync(new PaginationParams
            {
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                Search = paginationParams.Search,
            });
            return Ok(expense);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(ExpenseRequestModel model)
        {
            var result = await _expenseervice.AddAsync(model);

            if (!result.IsError)
            {
                return StatusCode(StatusCodes.Status201Created, result);
            }
            return BadRequest(result);
        }

        [HttpPost("update/{Id:int}")]
        public async Task<IActionResult> UpdateAsync(int Id, ExpenseRequestModel model)
        {
            var result = await _expenseervice.UpdateAsync(Id, model);

            if (!result.IsError)
            {
                return StatusCode(200, result);
            }

            return NotFound(result);
        }

        [HttpGet("getbyId/{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _expenseervice.GetByIdAsync(Id);

            if (!result.IsError)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _expenseervice.DeleteAsync(Id);

            if (!result.IsError)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

    }
}
