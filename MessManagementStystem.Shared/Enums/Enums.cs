using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Enums
{
	public class Enums
	{
		public enum MealType
		{
			Lunch= 1,
			Dinner = 2,
		}
		public enum DayOfWeekEnum
		{
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		}
		public enum PresenceStatus { 
			Present = 1,
		   Absent = 2
		}
	}
}
