using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
	public class UserManagerResponseModel
	{
		public string Message { get; set; }
		public string Token { get; set; }
		public int UserId { get; set; }
		public bool IsSuccess { get; set; }
		public IEnumerable<string> Errors { get; set; }
		public DateTime? ExpireDate { get; set; }
        public string Role { get; set; }
        public int? RoleId { get; set; }

    }
}
