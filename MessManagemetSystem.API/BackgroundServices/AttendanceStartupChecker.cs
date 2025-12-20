using MessManagemetSystem.API.Services.IService;
using Quartz;

namespace MessManagemetSystem.API.BackgroundServices
{
	public class AttendanceStartupChecker : IHostedService
	{
		private readonly ISchedulerFactory _schedulerFactory;
		private readonly ILastRunRepository _lastRunRepository;
		private readonly ILogger<AttendanceStartupChecker> _logger;

		public AttendanceStartupChecker(
			ISchedulerFactory schedulerFactory,
			ILastRunRepository lastRunRepository,
			ILogger<AttendanceStartupChecker> logger)
		{
			_schedulerFactory = schedulerFactory;
			_lastRunRepository = lastRunRepository;
			_logger = logger;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			var nowPakistan = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
				TimeZoneInfo.FindSystemTimeZoneById("Asia/Karachi"));
			var today = nowPakistan.Date;

			_logger.LogInformation($"[StartupChecker] App started at {nowPakistan:yyyy-MM-dd HH:mm:ss} PKT");

			var lastRun = await _lastRunRepository.GetLastRunDateAsync();
			if (lastRun != today)
			{
				_logger.LogInformation("[StartupChecker] Attendance job has not run today — triggering now.");
				var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
				await scheduler.TriggerJob(new JobKey("DailyAttendanceJob"), cancellationToken);
			}
			else
			{
				_logger.LogInformation("[StartupChecker] Attendance job already ran today — no need to trigger.");
			}
		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
	}



}
