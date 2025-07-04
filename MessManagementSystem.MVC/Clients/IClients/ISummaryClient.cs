using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.IClients
{
    public interface ISummaryClient
    {
        public Task<SummaryResponseModel> GetSummaryAsync(int userId, DateTime date);
    }
}
