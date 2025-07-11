using MessManagemetSystem.API.Enums;
using MessManagemetSystem.API.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Seeds
{
	public static class SeedInitial
	{
		public static void SeedsEntity(ModelBuilder modelBuilder)
		{
			


			modelBuilder.Entity<PermissionEntity>()
			.HasData(
				new PermissionEntity { Id = 1, Name = AdminPermissions.Admin.ToString() },
				new PermissionEntity { Id = 2, Name = AdminPermissions.Student.ToString() },
				new PermissionEntity { Id = 3, Name = AdminPermissions.Operator.ToString() }
				);

			modelBuilder.Entity<RolePermissionEntity>()
			.HasData(
			   new RolePermissionEntity() { Id = 1, RoleId = 1, PermissionId = 1 },
			   new RolePermissionEntity() { Id = 2, RoleId = 2, PermissionId = 2 },
			   new RolePermissionEntity() { Id = 3, RoleId = 3, PermissionId = 3 });

		



			modelBuilder.Entity<UserRoles>().HasData(
		    new UserRoles { Id = 1,Name = "Admin",NormalizedName = "Admin",ConcurrencyStamp = Guid.NewGuid().ToString()},
			new UserRoles { Id = 2, Name = "Student", NormalizedName ="Student", ConcurrencyStamp = Guid.NewGuid().ToString()},
			new UserRoles { Id = 3, Name = "Operator", NormalizedName ="Operator", ConcurrencyStamp = Guid.NewGuid().ToString()}
			);

			//create user
			var appUser = new ApplicationUser
			{
				Id = 1,
				Email = "mudassar@yopmail.com",
				EmailConfirmed = true,
				FirstName = "Mudassar",
				LastName = "Mushtaq",
				UserName = "mudassar@yopmail.com",

				NormalizedUserName = "mudassar@yopmail.com",
				NormalizedEmail = "mudassar@yopmail.com",
				Active = true,
				RoleId = 1, // may error occur

			};

			//set user password
			PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
			appUser.PasswordHash = ph.HashPassword(appUser, "Admin@123");

			//seed user
			modelBuilder.Entity<ApplicationUser>().HasData(appUser);

			//set user role to admin
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
			{

				RoleId = 1,
				UserId = 1
			});
		}
	}

}
