using System.Globalization;

namespace MessManagemetSystem.API.Helper
{
    public  static class HelperClass{

    public static DateTime? TryParseMonthOrYear(string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return null;

        search = search.Trim().ToLower();

        // Try parsing full date (e.g., 12-2025, 01/07/2025)
        if (DateTime.TryParse(search, out var fullDate))
            return fullDate;

        // Try parsing month name (e.g., "july")
        var monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                          .Where(m => !string.IsNullOrEmpty(m)).ToList();

        for (int i = 0; i < monthNames.Count; i++)
        {
            if (monthNames[i].ToLower().Contains(search))
            {
                // Assume current year if year not specified
                return new DateTime(DateTime.Now.Year, i + 1, 1);
            }
        }

        // Try parsing year (e.g., "2025")
        if (int.TryParse(search, out int year) && year >= 1900 && year <= 2100)
        {
            return new DateTime(year, 1, 1); // Beginning of the year
        }

        return null;
    }

}
}