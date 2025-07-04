namespace MessManagemetSystem.API.Identity
{
	public class PermissionEntity : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public virtual RolePermissionEntity RolePermission { get; set; }

	}
}
