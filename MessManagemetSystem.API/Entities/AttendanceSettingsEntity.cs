using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations;

namespace MessManagemetSystem.API.Entities
{
	public class AttendanceSettingsEntity  : BaseEntity
	{
		[Required]
		[Display(Name = "Start Time")]
		public TimeSpan StartTime { get; set; }

		[Required]
		[Display(Name = "End Time")]
		public TimeSpan EndTime { get; set; }
	}
}
