using MessManagemetSystem.API.Services.IService;
using Quartz;

namespace MessManagemetSystem.API.BackgroundServices
{
	public class AttendanceJob : IJob
	{
		private readonly ILogger<AttendanceJob> _logger;
		private readonly IAttendanceService _attendanceService;
		private readonly ILastRunRepository _lastRunRepository;

		public AttendanceJob(
			ILogger<AttendanceJob> logger,
			IAttendanceService attendanceService,
			ILastRunRepository lastRunRepository)
		{
			_logger = logger;
			_attendanceService = attendanceService;
			_lastRunRepository = lastRunRepository;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			var nowPakistan = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
				TimeZoneInfo.FindSystemTimeZoneById("Asia/Karachi"));
			var today = nowPakistan.Date;

			_logger.LogInformation($"[AttendanceJob] Execution triggered at {nowPakistan:yyyy-MM-dd HH:mm:ss} PKT");

			var lastRun = await _lastRunRepository.GetLastRunDateAsync();
			if (lastRun == today)
			{
				_logger.LogInformation("[AttendanceJob] Skipping — already ran today.");
				return;
			}

			_logger.LogInformation("[AttendanceJob] Starting attendance process...");
			try
			{
				await _attendanceService.MarkAutoAttenance(CancellationToken.None);
				await _lastRunRepository.SetLastRunDateAsync(today);
				_logger.LogInformation("[AttendanceJob] Attendance process completed successfully.");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[AttendanceJob] Error during attendance process.");
			}
		}
	}



}
