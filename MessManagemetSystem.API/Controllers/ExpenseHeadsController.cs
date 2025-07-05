using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagemetSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseHeadsController : ControllerBase
	{
		private readonly IExpenseHeadsService _expenseHeadService;
		public ExpenseHeadsController(IExpenseHeadsService expenseHeadsService)
		{ _expenseHeadService = expenseHeadsService; }


		[HttpPost("get")]
		public async Task<IActionResult> GetAsync([FromBody] PaginationParams paginationParams)
		{
			var expenseHeads = await _expenseHeadService.GetAsync(new PaginationParams
			{
				PageNumber = paginationParams.PageNumber,
				PageSize = paginationParams.PageSize,
				Search = paginationParams.Search,
			});
			return Ok(expenseHeads);
		}

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var expenseHeads = await _expenseHeadService.GetAsync();
            return Ok(expenseHeads);
        }

        [HttpPost("add")]
		public async Task<IActionResult> AddAsync(ExpenseHeadsRequestModel model)
		{
			var result = await _expenseHeadService.AddAsync(model);

			if (!result.IsError)
			{
				return StatusCode(StatusCodes.Status201Created, result);
			}
			return BadRequest(result);
		}

		[HttpPost("update/{Id:int}")]
		public async Task<IActionResult> UpdateAsync(int Id, ExpenseHeadsRequestModel model)
		{
			var result = await _expenseHeadService.UpdateAsync(Id, model);

			if (!result.IsError)
			{
				return StatusCode(200, result);
			}

			return NotFound(result);
		}

		[HttpGet("getbyId/{Id}")]
		public async Task<IActionResult> GetByIdAsync(int Id)
		{
			var result = await _expenseHeadService.GetByIdAsync(Id);

			if (!result.IsError)
			{
				return Ok(result);
			}

			return NotFound(result);
		}
		[HttpPost("delete/{Id}")]
		public async Task<IActionResult> DeleteAsync(int Id)
		{
			var result = await _expenseHeadService.DeleteAsync(Id);

			if (!result.IsError)
			{
				return Ok(result);
			}

			return NotFound(result);
		}

	}
}
