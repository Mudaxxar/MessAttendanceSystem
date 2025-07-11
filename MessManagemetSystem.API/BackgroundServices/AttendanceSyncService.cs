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
                if (DateTime.Now.Hour == 18)
                {
                    using var scope = _services.CreateScope();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRoles>>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<MessDbContext>();
                    var roles = await roleManager.Roles.ToListAsync();
                    string studentRole = roles[1].Name;
                    var students = (await userManager.GetUsersInRoleAsync(studentRole)).ToList();


                    var allUsers = await userManager.Users.ToListAsync();
					foreach (var user in allUsers)
					{
						var userRoles = await userManager.GetRolesAsync(user);
						Console.WriteLine($"{user.UserName}: {string.Join(", ", userRoles)}");
					}

					var user1 = await userManager.FindByEmailAsync("user@yopmail.com");
					var roles1 = await userManager.GetRolesAsync(user1);

					Console.WriteLine($"{user1.Email} roles: {string.Join(", ", roles)}");
					foreach (var student in students)
                    {
                        bool exists = await dbContext.Attendance
							.AnyAsync(a => a.ApplicationUserId == student.Id && a.Date == DateTime.Today.AddDays(1));
                        if (!exists)
                        {
                            dbContext.Attendance.Add(new AttendanceEntity
                            {
                                ApplicationUserId = student.Id,
                                Date = DateTime.Today.AddDays(1),
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
