using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class AttendanceResponseModel
    {
		public int Id { get; set; }
		public int? UserId { get; set; } 
		public string? UserName { get; set; } 
		public string? Class { get; set; } 
		public string? MessNumber { get; set; } 
		public DateTime Date { get; set; } 
		public PresenceStatus Status { get; set; }
	}
}
