using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static MessManagementSystem.Shared.Enums.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MessManagemetSystem.API.Services.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public AttendanceService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

		public async Task<PaginatedResponseModel<AttendanceResponseModel>> GetAttendanceAsync(PaginationParams dtParams)
		{
			var repo = _unitOfWork.GetRepository<AttendanceEntity>();
			var query =  repo.GetAll();
            query = query.Include(c => c.ApplicationUser);

            if (dtParams.UserId != null && dtParams.UserId != 0)
            {
                query = query.Where(x => x.ApplicationUserId == dtParams.UserId);
            }

			if (!string.IsNullOrEmpty(dtParams.Search))
			{

				query = query.Where(search =>
										search.ApplicationUser.FirstName.ToLower().Contains(dtParams.Search.ToLower()) ||
										search.ApplicationUser.MessNumber.ToLower().Contains(dtParams.Search.ToLower()) ||
										search.ApplicationUser.BatchClass.ToLower().Contains(dtParams.Search.ToLower()) ||
										search.ApplicationUser.Email.ToLower().Contains(dtParams.Search.ToLower()));
			}
			var totalRecords = await query.CountAsync();
			var paginatedResult = await PaginatedHelper<AttendanceEntity>.GetPaginatedRecored(query, x => x.Date, dtParams);

			var response = paginatedResult.Select(x => new AttendanceResponseModel
			{
				Id = x.Id,
				Date = x.Date,
                UserId = x.ApplicationUserId,
				Status = x.Status,
				UserName = x.ApplicationUser.FirstName,
                Class = x.ApplicationUser.BatchClass,
				MessNumber = x.ApplicationUser.MessNumber,
                

			}).ToList();

			return new PaginatedResponseModel<AttendanceResponseModel>
			{
				TotalRecords = totalRecords,
				Records = response,
				PaginationParam = dtParams
			};
		}

		public async Task<bool> MarAttendance(AttendanceRequestModel model)
        {
            try
            {
             model.AttendanceCount = model.Status == PresenceStatus.Present ? model.AttendanceCount : 0;
             model.Date = model.Date == null ? DateTime.Now.Date.AddDays(1) : model.Date;

            var student = await _userService.GetByIdAsync(model.UserId);
            if (student != null)
            {
                var repo = _unitOfWork.GetRepository<AttendanceEntity>();
                var alreadyMarked = await repo.FirstOrDefaultAsync(x => x.ApplicationUserId == student.Id && x.Date == DateTime.Today.AddDays(1));

                if (alreadyMarked == null)
                {
                    await repo.AddAsync(new AttendanceEntity
                    {
                        ApplicationUserId = student.Id,
                        Date = Convert.ToDateTime(model.Date),
                        Status = model.Status,
                        AttendanceCount = model.AttendanceCount,
                    });
                }
                else
                {
                    alreadyMarked.Date = DateTime.Today;
                    alreadyMarked.Status = model.Status;
                    await repo.UpdateAsync(alreadyMarked.Id, alreadyMarked);
                }
                 model.UserId = student.Id;
                await _userService.UpdateAttendance(model); // Update User status as well.
                await _unitOfWork.CommitAsync();
                return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
