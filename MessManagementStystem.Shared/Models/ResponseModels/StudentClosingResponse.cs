using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class StudentClosingResponse
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int? AttendanceCount { get; set; }
        public decimal? MealAmount { get; set; }
        public double? Advance { get; set; }
        public double? Previous { get; set; }
        public decimal? Total { get; set; }
        public decimal? MealPerHead { get; set; }
    }
}
