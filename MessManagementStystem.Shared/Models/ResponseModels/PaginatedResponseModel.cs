using MessManagementSystem.Shared.Models;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class PaginatedResponseModel<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Records { get; set; }
        public PaginationParams PaginationParam { get; set; }
    }
}
