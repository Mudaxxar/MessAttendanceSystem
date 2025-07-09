using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessManagemetSystem.API.Entities
{
	public class AccountsEntity : BaseEntity
	{
		[ForeignKey("ApplicationUserId")]
		public int ApplicationUserId { get; set; } // as student Id
		public ApplicationUser ApplicationUser { get; set; }
		public DateTime? Date { get; set; }
		public decimal Credit { get; set; } = 0;
		public decimal Debit { get; set; } = 0;
		public decimal Balance { get; set; } = 0;
		public string? Description { get; set; }
	}
}
