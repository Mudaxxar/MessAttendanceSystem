using MessManagementSystem.Shared;

namespace MessManagemetSystem.API.Services.IService
{
	public interface ILastRunRepository
	{
		Task<DateTime?> GetLastRunDateAsync();
		Task SetLastRunDateAsync(DateTime date);
	}

	public class FileLastRunRepository : ILastRunRepository
	{
		private readonly string _filePath;
		private readonly ILogger<FileLastRunRepository> _logger;

		public FileLastRunRepository(IWebHostEnvironment env, ILogger<FileLastRunRepository> logger)
		{
			_logger = logger;

			var folder = Path.Combine(env.ContentRootPath, "App_Data");
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			_filePath = Path.Combine(folder, "LastAttendanceRun.txt");
			_logger.LogInformation($"Last run file path: {_filePath}");
		}

		public async Task<DateTime?> GetLastRunDateAsync()
		{
			if (!File.Exists(_filePath))
			{
				_logger.LogInformation("No last run file found — job has never run.");
				return null;
			}

			var text = await File.ReadAllTextAsync(_filePath);
			if (DateTime.TryParse(text, out var date))
			{
				_logger.LogInformation($"Last run date loaded: {date:yyyy-MM-dd}");
				return date.Date;
			}

			_logger.LogWarning("Last run file found but invalid date format.");
			return null;
		}

		public async Task SetLastRunDateAsync(DateTime date)
		{
			await File.WriteAllTextAsync(_filePath, date.ToString("yyyy-MM-dd"));
			_logger.LogInformation($"Last run date saved: {date:yyyy-MM-dd}");
		}
	}




}
