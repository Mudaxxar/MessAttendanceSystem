using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagementSystem.Shared.Models.RequestModels
{
    public class MenuRequestModel
    {
        public DayOfWeekEnum DayOfWeek { get; set; }
        public MealType MealType { get; set; }
        public string MenuItems { get; set; }
    }
}
