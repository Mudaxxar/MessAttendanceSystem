namespace MessManagemetSystem.API.Helper
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
