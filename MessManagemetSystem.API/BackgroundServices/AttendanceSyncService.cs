using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API
{
    public class AttendanceSyncService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public AttendanceSyncService(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var todayAt4PM = DateTime.Today.AddHours(0); // 12 PM today

                // If already past 4 PM, schedule for tomorrow
                var nextRunTime = now > todayAt4PM
                    ? todayAt4PM.AddDays(1)
                    : todayAt4PM;

                var delay = nextRunTime - now;

                await Task.Delay(delay, stoppingToken); // ⏳ Wait until 4 PM

                if (stoppingToken.IsCancellationRequested)
                    break;

                try
                {
                    using var scope = _services.CreateScope();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRoles>>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<MessDbContext>();

                    var students = await dbContext.Users
                        .Include(x => x.Role)
                        .Where(r => r.Role.Name.ToLower() == "student")
                        .ToListAsync(stoppingToken);

                    foreach (var student in students)
                    {
                        bool exists = await dbContext.Attendance.AnyAsync(a =>
                            a.ApplicationUserId == student.Id &&
                            a.Date == DateTime.Today.AddDays(1), stoppingToken);

                        if (!exists)
                        {
                            dbContext.Attendance.Add(new AttendanceEntity
                            {
                                ApplicationUserId = student.Id,
                                Date = DateTime.Today.AddDays(1),
                                Status = student.Status,
                                AttendanceCount = 1
                            });
                        }
                    }

                    await dbContext.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    // Optional: Log error
                }
            }
        }

    }

}
