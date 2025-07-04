using MessManagemetSystem.API.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessManagemetSystem.API.Entities
{
   
    public class FeedbackEntity : BaseEntity
    {

		[ForeignKey("ApplicationUserId")]
		public int ApplicationUserId { get; set; } // as student Id
		public ApplicationUser ApplicationUser { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comments { get; set; }
    }
}
