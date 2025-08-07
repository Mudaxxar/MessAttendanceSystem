using MessManagementSystem.Shared;
using MessManagemetSystem.API.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessManagemetSystem.API.Identity
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; } = PSTTimeProvider.Now;
		public DateTime? UpdatedOn { get; set; }
		public int? CreatedBy { get; set; } 
		public int? UpdatedBy { get; set; }
		public bool IsDeleted { get; set; } = false;
		public bool IsActive { get; set; } = true;
		public string? IP { get; set; }
	}
}
