using System.ComponentModel.DataAnnotations;

namespace MessManagementSystem.Shared.Models.RequestModels
{
    public class LoginRequestModel
    {

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
