using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
   public class ExpenseResponseModel
    {
        public int Id { get; set; } 
        public decimal Amount { get; set; }
        public DateTime? Date  { get; set; }
        public string Description { get; set; }
        public int? ExpenseHeadId { get; set; } // Foreign key to ExpenseHeadEntity
        public string? ExpenseHeadName { get; set; } // Name of the expense head

    }
}
