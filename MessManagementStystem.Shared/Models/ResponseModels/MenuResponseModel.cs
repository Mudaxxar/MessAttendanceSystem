using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class MenuResponseModel
    {
        public int Id { get; set; }
        public DayOfWeekEnum DayOfWeek { get; set; }
        public MealType MealType { get; set; }
        public string MenuItems { get; set; }
    }
}
