namespace MessManagemetSystem.API.Helper
{
    public class PakistanTimeProvider : ITimeProvider
    {
        private static readonly TimeZoneInfo _timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Karachi");

        public DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone);
        public DateTime Today => Now.Date;
    }
}
