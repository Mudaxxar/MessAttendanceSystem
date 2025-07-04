using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MessManagementSystem.Shared.Models.RequestModels
{
    public class RolesRequestModel
    {
		public int? Id { get; set; }
		public string Name { get; set; }
		public string? NormalizedName { get; set; }
		public ICollection<int>? Permissions { get; set; }
	}
}
