using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
	public class WeeklyMenuViewModel
	{
		public MealType MealType { get; set; } // Lunch or Dinner
		public Dictionary<string, string> DailyItems { get; set; } = new(); // Monday -> "Chicken"
    }

}
