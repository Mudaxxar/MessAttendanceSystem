using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Extensions;
using MessManagemetSystem.API.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MessManagemetSystem.API.DbContext
{
	public class MessDbContext : IdentityDbContext<ApplicationUser, UserRoles, int>
	{

		public MessDbContext(DbContextOptions<MessDbContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			DbContextExtension.RegisterDbContextDependencies(modelBuilder); // relationShips Dependency Class
			//GlobalQueryFiltering.RegisterGlobalQuery(modelBuilder); //Golobal query
		}
		public DbSet<MenuEntity> Menus { get; set; }
		public DbSet<AttendanceEntity> Attendances { get; set; }
		public DbSet<FeedbackEntity> Feedbacks { get; set; }
		public DbSet<ExpenseHeadEntity> ExpenseHead{ get; set; }
		public DbSet<ExpenseEntity> Expenses { get; set; }
		public DbSet<AccountsEntity> Accounts { get; set; }
		public DbSet<StudentMealSummaryEntity> StudentMealSummarys { get; set; }
		public DbSet<MonthlyClosingEntity> MonthlyClosings { get; set; }
	}
}
