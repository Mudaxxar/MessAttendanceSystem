using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.RequestModels
{
   public class StudentStatementRequestModel
    {
        public DateTime Date { get; set; }
        public PaginationParams PaginationParams { get; set; }

    }
}
