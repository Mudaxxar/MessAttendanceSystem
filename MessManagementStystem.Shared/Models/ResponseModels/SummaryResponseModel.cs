using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class SummaryResponseModel
    {
        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
        public int MealsCount { get; set; }
        public int TotalCount { get; set; }
        public List<UserResponseModel> RecentlyRegister { get; set; }
        public List<FeedbackResponseModel> RecentlyFeedbacks { get; set; }
    }
}
