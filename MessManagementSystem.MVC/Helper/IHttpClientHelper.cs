namespace MessManagementSystem.MVC.Helper
{
    public interface IHttpClientHelper
    {
        Task<T> PostAsync<T>(string endpoint, object data);
        Task<string> PostAsync(string endpoint, object data);
        Task<T> GetAsync<T>(string endpoint);
        Task<string> GetAsync(string endpoint);
    }
}
