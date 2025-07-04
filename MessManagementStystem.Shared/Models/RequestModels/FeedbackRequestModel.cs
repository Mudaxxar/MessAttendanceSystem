using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.RequestModels
{
	public class FeedbackRequestModel
	{
		public int? UserId { get; set; } = 0;
		public string Comments { get; set; } = string.Empty;
	}
}
