namespace MessManagemetSystem.API.Identity
{
	public class RolePermissionEntity : BaseEntity
	{
		public int RoleId { get; set; }
		public virtual UserRoles Role { get; set; }
		public int PermissionId { get; set; }
		public virtual PermissionEntity Permission { get; set; }
	}
}
