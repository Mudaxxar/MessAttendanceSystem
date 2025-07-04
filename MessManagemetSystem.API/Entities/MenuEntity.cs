using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Entities
{
	public class MenuEntity: BaseEntity
	{
        //public DateTime Date { get; set; }
        public DayOfWeekEnum DayofWeek { get; set; }

		public MealType MealType { get; set; }
        public string MenuItems { get; set; } // JSON string to store menu items
	}
}
