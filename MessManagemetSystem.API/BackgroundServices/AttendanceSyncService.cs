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
                if (DateTime.Now.Hour == 0)
                {
                    using var scope = _services.CreateScope();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRoles>>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<MessDbContext>();
                    var roles = await roleManager.Roles.ToListAsync();
                    string studentRole = roles[1].Name;
                    var students = (await userManager.GetUsersInRoleAsync(studentRole)).ToList();


                    //var allUsers = await userManager.Users.ToListAsync();
                    //foreach (var user in allUsers)
                    //{
                    //    var userRoles = await userManager.GetRolesAsync(user);
                    //    Console.WriteLine($"User: {user.UserName} - Roles: {string.Join(", ", userRoles)}");
                    //}


                    foreach (var student in students)
                    {
                        bool exists = await dbContext.Attendance
							.AnyAsync(a => a.ApplicationUserId == student.Id && a.Date == DateTime.Today);
                        if (!exists)
                        {
                            dbContext.Attendance.Add(new AttendanceEntity
                            {
                                ApplicationUserId = student.Id,
                                Date = DateTime.Today,
                                Status = student.Status
                            });
                        }
                    }

                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromHours(4), stoppingToken);
                //await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }

}
