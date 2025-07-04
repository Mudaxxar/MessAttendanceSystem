using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessManagemetSystem.API.Entities
{
	public class StudentMealSummaryEntity : BaseEntity
	{
		[ForeignKey("ApplicationUserId")]
		public int ApplicationUserId { get; set; } // as student Id
		public ApplicationUser ApplicationUser { get; set; }
		public int TotalMealTaken { get; set; }
		public double MealPerHead { get; set; }
		public int AbsentDays { get; set; }
		public DateTime Date { get; set; }
		public double TotalAmount { get; set; }

	}
}
