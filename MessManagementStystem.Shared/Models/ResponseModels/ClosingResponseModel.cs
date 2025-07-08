using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class ClosingResponseModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int TotalAttendance { get; set; }
        public double PerMealAmount { get; set; }
    }
}
