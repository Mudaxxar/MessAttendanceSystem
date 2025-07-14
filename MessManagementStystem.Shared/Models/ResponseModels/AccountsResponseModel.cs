using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class AccountsResponseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double? SecurityFees { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
