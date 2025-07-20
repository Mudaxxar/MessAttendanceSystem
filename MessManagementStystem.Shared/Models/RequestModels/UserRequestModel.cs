using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.RequestModels
{
   public class UserRequestModel
    {
		[DisplayName("First Name")]
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string Role { get; set; }
		public int RoleId { get; set; }
		public string MessNumber { get; set; }
		public string BatchClass { get; set; }
		public double SecurityFees { get; set; } = 0;
		public double Balance { get; set; } = 0;

	}
}
