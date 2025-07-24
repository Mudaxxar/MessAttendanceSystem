using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class AttendanceSettingsResponseModel
    {
		[Display(Name = "Start Time")]
		public TimeSpan StartTime { get; set; }

		[Display(Name = "End Time")]
		public TimeSpan EndTime { get; set; }
	}
}
