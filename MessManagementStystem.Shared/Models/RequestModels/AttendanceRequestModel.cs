using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagementSystem.Shared.Models.RequestModels
{
    public class AttendanceRequestModel
    {
        public PresenceStatus Status { get; set; }
        public string? UserEmail { get; set; } 
        public int UserId { get; set; } 
        public int AttendanceCount { get; set; } = 1;
        public DateTime? Date { get; set; } = null;// this is set to null because Student's Attendance marked as next day.
    }
}
