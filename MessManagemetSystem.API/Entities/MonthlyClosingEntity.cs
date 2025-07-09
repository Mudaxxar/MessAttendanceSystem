using MessManagemetSystem.API.Identity;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Entities
{
    public class MonthlyClosingEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int? TotalAttendance { get; set; }
        public int? TotalMeals { get; set; }
        public decimal? MealPerHead { get; set; }
        public ClosingStatus? Status { get; set; } 

       
    }

}
