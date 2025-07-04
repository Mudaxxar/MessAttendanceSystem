using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
	public class FeedbackResponseModel
	{
		public int Id { get; set; }
		public UserResponseModel ApplicationUser { get; set; }
		public string UserName { get; set; }
		public string Comments { get; set; }
		public DateTime CreatedOn { get; set; }
	}
	
}
