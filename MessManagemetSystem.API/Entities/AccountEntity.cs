using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessManagemetSystem.API.Entities
{
	public class AccountEntity : BaseEntity
	{
		[ForeignKey("ApplicationUserId")]
		public int ApplicationUserId { get; set; } // as student Id
		public ApplicationUser ApplicationUser { get; set; }
		public decimal Balance { get; set; } = 0;
		public decimal TotalCredit { get; set; } = 0;
		public decimal TotalDebit { get; set; } = 0;
		public string? Remarks { get; set; }
		public DateTime? Date { get; set; }
	}
}
