using MessManagemetSystem.API.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Identity
{
	public class ApplicationUser : IdentityUser<int>
	{
		public ApplicationUser() : base()
		{

		}
		public int UserType { get; set; }
		public int CompanyId { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public bool? Active { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string? FirstName { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string? LastName { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string? DecodedPassword { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string? Password { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[ForeignKey("RoleId")]
		public int? RoleId { get; set; }
		public virtual UserRoles? Role { get; set; }
		public PresenceStatus Status { get; set; } = PresenceStatus.Absent;
		public DateTime? LastStatusChange { get; set; } = null;
		public double SecurityFees { get; set; } = 0;
		public double Balance { get; set; } = 0;
		public string? MessNumber { get; set; } 
		public string? BatchClass { get; set; } 
		public ICollection<AttendanceEntity> Attendances { get; set; }

    }
}
