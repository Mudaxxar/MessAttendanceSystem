using MessManagemetSystem.API.Identity;

namespace MessManagemetSystem.API.Entities
{
	public class ExpenseEntity : BaseEntity
	{
		public int? ExpenseHeadId { get; set; } // Foreign key to ExpenseHeadEntity
		public ExpenseHeadEntity? ExpenseHead { get; set; }
		public decimal Amount { get; set; }
		public string? Description { get; set; }
		public DateTime? Date { get; set; }
	
}
}
