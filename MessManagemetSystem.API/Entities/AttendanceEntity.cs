using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Entities
{
	public class AttendanceEntity : BaseEntity
	{
		[ForeignKey("ApplicationUserId")]
		public int ApplicationUserId { get; set; } // as student Id
		public ApplicationUser ApplicationUser { get; set; }
		public DateTime Date { get; set; }
		public PresenceStatus Status { get; set; }
		public int MealsCount { get; set; } = 1;
	}
}
