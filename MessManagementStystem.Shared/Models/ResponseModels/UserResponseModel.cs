using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
	public class UserResponseModel
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string Email { get; set; }
		public bool? Active { get; set; }
		public string Role { get; set; }
		public string? MessNumber { get; set; }
		public string? BatchClass { get; set; }
		public double? Balance { get; set; }
		public double? SecurityFees { get; set; }

	}
}
