using MessManagementSystem.Shared;
using MessManagemetSystem.API.Services.IService;
using MessManagemetSystem.API.Services.Service;
using Quartz;

namespace MessManagemetSystem.API.BackgroundServices
{
	public class QuartzBackgroundJob : IJob
	{
		private readonly ILogger<QuartzBackgroundJob> _logger;
		private readonly IAttendanceService _attendanceService;

		public QuartzBackgroundJob(ILogger<QuartzBackgroundJob> logger
			, IAttendanceService attendanceService)
		{
			_logger = logger;
			_attendanceService = attendanceService;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation($"Attendance Service start  executed at {PSTTimeProvider.Now}");
			await _attendanceService.MarkAutoAttenance(CancellationToken.None);
			_logger.LogInformation($"Attendance Service start  done at {PSTTimeProvider.Now}");

		}
	}
}
