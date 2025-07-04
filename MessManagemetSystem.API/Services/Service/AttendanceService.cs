using MessManagementSystem.Shared.Models.RequestModels;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
        public async Task<bool> MarAttendance(AttendanceRequestModel model)
        {
            try
            {
            var student = await _userService.GetUser(model.userId);
            if (student != null)
            {
                var repo = _unitOfWork.GetRepository<AttendanceEntity>();
                var alreadyMarked = await repo.FirstOrDefaultAsync(x => x.ApplicationUserId == student.Id && x.Date == DateTime.Today);

                if (alreadyMarked == null)
                {
                    await repo.AddAsync(new AttendanceEntity
                    {
                        ApplicationUserId = student.Id,
                        Date = DateTime.Today,
                        Status = model.Status
                    });
                }
                else
                {
                    alreadyMarked.Date = DateTime.Today;
                    alreadyMarked.Status = model.Status;
                    await repo.UpdateAsync(alreadyMarked.Id, alreadyMarked);
                }
                 model.userId = student.Id.ToString();
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
