using MessManagementSystem.Shared;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API
{
    public class AttendanceSyncService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<AttendanceSyncService> _logger;

        public AttendanceSyncService(IServiceProvider services
            ,ILogger<AttendanceSyncService> logger
            )
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Execution of background Service Start");
				var now = PSTTimeProvider.Now;
               
                var todayAt2AM = PSTTimeProvider.Today.AddHours(19).AddMinutes(50); // Adjusted label
                var nextRunTime = now > todayAt2AM
                    ? todayAt2AM.AddDays(1)
                    : todayAt2AM;

                var delay = nextRunTime - now;
				_logger.LogInformation($"Next run time: {nextRunTime}, Delay: {delay.TotalMinutes} minutes");

				await Task.Delay(delay, stoppingToken);

                if (stoppingToken.IsCancellationRequested)
                    break;

                try
                {
                    using (var scope = _services.CreateScope())
                    {
                        Console.WriteLine("Start of Attendance marked successfully.");
                        _logger.LogInformation("Start of Attendance marked successfully.");

                        var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();

                        await attendanceService.MarkAutoAttenance(stoppingToken);

                        Console.WriteLine("Attendance marked successfully.");
                        _logger.LogInformation("Attendance marked successfully.");

                    }
				}
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while marking attendance: {ex.Message}");
					_logger.LogError($"Error:{ ex.Message}" );
				}
            }

        }
    }
}