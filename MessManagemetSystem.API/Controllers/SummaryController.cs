using AutoMapper;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly MessDbContext _context;
        private readonly IMapper _mapper;
        public SummaryController(MessDbContext messDbContext
            , IMapper mapper)
        {
            _context = messDbContext;
            _mapper = mapper;
        }
        [HttpGet("summary")]
        public async Task<SummaryResponseModel> GetDailySummary(DateTime? date = null)
        {
            date ??= DateTime.Today;
            var presentCount = await _context.Attendances.CountAsync(a => a.Date == date && a.Status == PresenceStatus.Present);
            var absentCount = await _context.Attendances.CountAsync(a => a.Date == date && a.Status == PresenceStatus.Absent);
            var totalStudents = await _context.Users.Where(x=>x.RoleId == 2).CountAsync();

            //Recent User Registered
            var recentUserRegister =  _context.Users.OrderByDescending(x=>x.CreatedOn).Take(10).ToList();
           var mappedUsers = _mapper.Map<List<UserResponseModel>>(recentUserRegister);


			//Recent Feedbacks
			var recentFeedback = _context.Feedbacks
                .Include(x=>x.ApplicationUser).OrderByDescending(x => x.CreatedOn).Take(10).ToList();
			var mapperFeedbacks = _mapper.Map<List<FeedbackResponseModel>>(recentFeedback);

			return (new SummaryResponseModel
            {
                PresentCount = presentCount,
                AbsentCount = absentCount,
                TotalCount = totalStudents,
                RecentlyRegister = mappedUsers,
                RecentlyFeedbacks = mapperFeedbacks
            });
			}
    }
}
