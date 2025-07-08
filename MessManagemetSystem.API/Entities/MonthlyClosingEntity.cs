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
        public ClosingStatus? Status { get; set; } 

        // Calculated property
        public int? AmountPerMeal
        {
            get
            {
                if (TotalAttendance.HasValue && TotalAttendance != 0)
                {
                    return (int)(Amount / TotalAttendance.Value);
                }
                return null;
            }
        }
    }

}
