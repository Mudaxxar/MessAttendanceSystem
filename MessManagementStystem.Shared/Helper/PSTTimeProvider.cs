namespace MessManagementSystem.Shared
{
    public static class PSTTimeProvider
    {
        private static readonly TimeZoneInfo _pakistanTimeZone =
           TimeZoneInfo.FindSystemTimeZoneById("Asia/Karachi");
        public static DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _pakistanTimeZone);
        public static DateTime Today => Now.Date;
    }
}
