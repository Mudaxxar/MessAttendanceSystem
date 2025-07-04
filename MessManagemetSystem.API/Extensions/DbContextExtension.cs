using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Seeds;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Extensions
{
	public static class DbContextExtension
	{
		public static void RegisterDbContextDependencies(this ModelBuilder modelBuilder)
		{
			//Seed Initials

			SeedInitial.SeedsEntity(modelBuilder);

			//IndexingExtension.SeedIndexing(modelBuilder);

			//Role Permission

			modelBuilder.Entity<RolePermissionEntity>()
				.HasKey(x => new { x.RoleId, x.PermissionId }); // composit key, so don't allow one role same permission mulitple time
			modelBuilder.Entity<RolePermissionEntity>();
			//   .HasData(Create(Permission.ReadMember));

		
			modelBuilder.Entity<UserRoles>()
				.HasMany(x => x.RolePermissions)
				.WithOne(x => x.Role)
				.HasForeignKey(x => x.RoleId)
					   .OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<RolePermissionEntity>()
				.HasOne(x => x.Permission)
				.WithOne(x => x.RolePermission)
				.HasForeignKey<RolePermissionEntity>(x => x.PermissionId)
					   .OnDelete(DeleteBehavior.ClientSetNull);


		}
	}
}
