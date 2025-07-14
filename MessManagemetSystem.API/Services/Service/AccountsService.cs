using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Helper;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using static MessManagementSystem.Shared.Enums.Enums;

namespace MessManagemetSystem.API.Services.Service
{
	public class AccountsService : IAccountsService
	{
		private readonly MessDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public AccountsService(MessDbContext messDbContext
, IUnitOfWork unitOfWork          )
        {
            _dbContext = messDbContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<bool>> AddMonthlyClosingAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<ExpenseEntity>();
            // Check if the expense with the given ID exists and is open
            var existingExpense = await repo.FirstOrDefaultAsync(x => x.Id == id && x.Status == ClosingStatus.Open);
            if (existingExpense != null)
            {

                var totalexpensAmount = existingExpense.Amount;

                var totalAttendace = await _dbContext.Attendance
                    .Where(x => x.Date.Year == existingExpense.Date.Value.Year &&
                                x.Date.Month == existingExpense.Date.Value.Month)
                    .SumAsync(x => x.AttendanceCount);

                var mealPerHead = totalexpensAmount / (totalAttendace * 2);
                // Create a new MonthlyClosingEntity
                var monthlyClosing = new MonthlyClosingEntity
                {

                    Date = existingExpense.Date.Value,
                    Description = $"Monthly Closing for {existingExpense.Date.Value.ToString("MMMM yyyy")}",
                    Amount = totalexpensAmount,
                    TotalAttendance = totalAttendace,
                    TotalMeals = totalAttendace * 2, // Assuming 2 meals per day
                    MealPerHead = mealPerHead,
                    Status = ClosingStatus.Close,

                };

                // Add the monthly closing to the database
                var closingRepo = _unitOfWork.GetRepository<MonthlyClosingEntity>();
                await closingRepo.AddAsync(monthlyClosing);


                var usersRepo = _unitOfWork.GetRepository<ApplicationUser>();
                var Users = await usersRepo.GetIncludeAsync(
                    predicate: x => (x.
                                    Role.Name.ToLower() == "student" 
                                    || x.Role.Name.ToLower() == "staff") 
                                    && x.Attendances.Sum(a => a.AttendanceCount) >= 1,
                    include: x => x
                                  .Include(u => u.Role )
                                  .Include(u => u.Attendances)
                );

                foreach (var student in Users)
                {
                    var countStudentAttendance = await _dbContext.Attendance
                        .Where(x => x.ApplicationUserId == student.Id &&
                                    x.Date.Year == existingExpense.Date.Value.Year &&
                                    x.Date.Month == existingExpense.Date.Value.Month)
                        .SumAsync(a=>a.AttendanceCount);

                    var UserBalance = Convert.ToDecimal(student.Balance) - (countStudentAttendance * mealPerHead * 2); // Assuming 2 meals per day
                    
                    var userAccount = new AccountsEntity
                    {
                        ApplicationUserId = student.Id,
                        Credit = 0,
                        Debit = countStudentAttendance * mealPerHead * 2, // Assuming 2 meals per day
                        Date = existingExpense.Date.Value,
                        Balance = UserBalance,
                        Description = $"Monthly Closing for {existingExpense.Date.Value.ToString("MMMM yyyy")}",
                    };
                    var userAccountRepo = _unitOfWork.GetRepository<AccountsEntity>();
                    await userAccountRepo.AddAsync(userAccount);
                    student.Balance = Convert.ToDouble(UserBalance); // Update user balance
                    usersRepo.Update(student);
                }

                // Update the status to closed
                existingExpense.Status = ClosingStatus.Close;
                repo.Update(existingExpense);
                await _unitOfWork.CommitAsync();

                return new ApiResponse<bool>
                {
                    Description = "Successfully Updated!",
                    Message = "Successfully Updated",
                    IsError = false,
                    Succeeded = true
                };
            }
            return new ApiResponse<bool>
            {
                Description = "Error while Deleting!",
                Message = "Error while Deleting",
                IsError = false,
                Succeeded = true

            };

        }
        public async Task<PaginatedResponseModel<MonthlyClosingResponseModel>> GetMonthlyClosingAsync(PaginationParams pParams)
		{
			var query = _dbContext.MonthlyClosing.AsQueryable();
			if (!string.IsNullOrEmpty(pParams.Search))
			{
				var search = pParams.Search.Trim().ToLower();
				// Try to parse year
				if (int.TryParse(search, out int year))
				{
					query = query.Where(x => x.Date.Year == year);
				}
				else
				{
					// Try to parse month name
					var months = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
								{
									{ "jan", 1 }, { "january", 1 },
									{ "feb", 2 }, { "february", 2 },
									{ "mar", 3 }, { "march", 3 },
									{ "apr", 4 }, { "april", 4 },
									{ "may", 5 },
									{ "jun", 6 }, { "june", 6 },
									{ "jul", 7 }, { "july", 7 },
									{ "aug", 8 }, { "august", 8 },
									{ "sep", 9 }, { "september", 9 },
									{ "oct", 10 }, { "october", 10 },
									{ "nov", 11 }, { "november", 11 },
									{ "dec", 12 }, { "december", 12 }
								};

					if (months.TryGetValue(search, out int month))
					{
						query = query.Where(x => x.Date.Month == month);
					}
				} }
					var totalCount = await query.CountAsync();
					var result = await query
						.Select(x => new MonthlyClosingResponseModel
						{
							Date = x.Date,
							Amount = x.Amount,
							TotalAttendance = x.TotalAttendance,
							PerMealAmount = x.MealPerHead,
							Description = x.Description,


						})
						.ToListAsync();
				
			return new PaginatedResponseModel<MonthlyClosingResponseModel>()
			{
				TotalRecords = totalCount,
				Records = result,
				PaginationParam = pParams,

			};

		}

        public async Task<List<AccountsResponseModel>> GetStatementAsync(int UserId)
        {
            var accountStatement = await _dbContext.Accounts
                .Where(x => x.ApplicationUserId == UserId)
                .OrderByDescending(d=>d.Date)
                .Take(10)
                .ToListAsync();
            var result = accountStatement.Select(x => new AccountsResponseModel
            {
                UserId = x.ApplicationUserId,
                Credit = x.Credit,
                Debit = x.Debit,
                Date = x.Date,
                Balance = x.Balance,
                Description = x.Description
            }).ToList();

            return result;
        }
        public async Task<PaginatedResponseModel<StudentClosingResponse>> GetStudentsStatementAsync(StudentStatementRequestModel request)
        {

            var query = _dbContext.Accounts.AsQueryable();
            query = query.Where(x => x.Date.Value.Month == request.Date.Month && x.Date.Value.Year == request.Date.Year);

            if (!string.IsNullOrEmpty(request.PaginationParams.Search))
            {
                query = query.Include(x => x.ApplicationUser).ThenInclude(x => x.Attendances);

                query = query.Where(p => p.ApplicationUser.FirstName.ToLower().Contains(request.PaginationParams.Search)

                || p.ApplicationUser.MessNumber.ToLower().Contains(request.PaginationParams.Search)
                || p.ApplicationUser.BatchClass.ToLower().Contains(request.PaginationParams.Search)
                );

            }
            var mealPerHead = await _dbContext.MonthlyClosing
                .Where(x => x.Date.Year == request.Date.Year && x.Date.Month == request.Date.Month)
                .Select(x => x.MealPerHead)
                .FirstOrDefaultAsync();

            var totalCount = await query.CountAsync();
            var result = await query
                .Select(x => new StudentClosingResponse
                {
                    Name = x.ApplicationUser.FirstName,
                    Class = x.ApplicationUser.BatchClass,
                    AttendanceCount = x.ApplicationUser.Attendances.Sum(a => a.AttendanceCount),
                    MealAmount = (decimal)x.ApplicationUser.Attendances.Sum(a => a.AttendanceCount) * 2 * mealPerHead, // Assuming 2 meals per day
                    Advance = x.ApplicationUser.SecurityFees,
                    Previous = x.ApplicationUser.Balance,
                    Total = x.ApplicationUser.Attendances.Sum(a => a.AttendanceCount) * 2 * mealPerHead + (decimal)x.ApplicationUser.Balance,

                })
                .ToListAsync();

            return new PaginatedResponseModel<StudentClosingResponse>()
            {
                TotalRecords = totalCount,
                Records = result,
                PaginationParam = request.PaginationParams,

            };
        }
    }
}
