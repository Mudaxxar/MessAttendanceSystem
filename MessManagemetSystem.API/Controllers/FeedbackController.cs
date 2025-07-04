using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MessManagemetSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbackController : ControllerBase
	{
		private readonly MessDbContext _context;
		public FeedbackController(MessDbContext contxt)
		{
			_context = contxt;
		}

		[HttpPost("add-feedback")]
		public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackRequestModel input)
		{
			string email = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
			var feedback = new FeedbackEntity
			{
				Comments = input.Comments,
				ApplicationUserId = user.Id,
			};

			_context.FeedbackEntities.Add(feedback);
			await _context.SaveChangesAsync();

			var result = new ApiResponse<bool>
			{
				IsError = false,
				Description = "Successfully"
			};
			return Ok(result);
		}
		[HttpGet("get-feedbacks")]
		public async Task<IActionResult> GetFeedbacks()
		{
			var feedbacks = await _context.FeedbackEntities
				.Include(f => f.ApplicationUser)
				.Select(f => new FeedbackResponseModel
				{
					Id = f.Id,
					Comments = f.Comments,
					UserName = f.ApplicationUser.UserName,
					CreatedOn = f.CreatedOn
				}).OrderByDescending(o=> o.CreatedOn)
				.ToListAsync();

			return Ok(new ApiResponse<List<FeedbackResponseModel>>
			{
				IsError = false,
				Data = feedbacks,
				Description = "Feedbacks retrieved successfully"
			});
		}
	}
}