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
        public string? userId { get; set; } = "";
    }
}
