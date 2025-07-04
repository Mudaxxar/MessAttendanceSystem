namespace MessManagemetSystem.API.Services.IService
{
    public interface IPermissionService
    {
        Task<HashSet<string>> GetPermissionsAsync(int memberId);
    }
}
