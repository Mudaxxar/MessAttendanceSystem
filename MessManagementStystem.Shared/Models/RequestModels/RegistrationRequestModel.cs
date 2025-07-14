using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MessManagementSystem.Shared.Models.RequestModels
{
    public class RegistrationRequestModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password), StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }

		public string MessNumber { get; set; }
		public string BatchClass { get; set; }
		public double SecurityFees { get; set; } = 0;
		public double Balance { get; set; } = 0;


	}
}
