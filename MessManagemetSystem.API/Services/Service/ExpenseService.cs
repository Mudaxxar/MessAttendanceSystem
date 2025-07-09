using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagementSystem.Shared.Models;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static MessManagementSystem.Shared.Enums.Enums;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Identity;

namespace MessManagemetSystem.API.Services.Service
{
   
    public class ExpenseService : IExpenseService
    {
        private readonly MessDbContext _messDbContext;
        private readonly IUnitOfWork _unitOfWork;
        public ExpenseService(MessDbContext messDbContext
            , IUnitOfWork unitofWork)
        {
            this._messDbContext = messDbContext;
            _unitOfWork = unitofWork;
		}
        public async Task<ApiResponse<ExpenseResponseModel>> AddAsync(ExpenseRequestModel model)
        {
          
            var entity = new ExpenseEntity
            {
                ExpenseHeadId = model.ExpenseHeadId,
                Description = model.Description,
                Amount = model.Amount,
                Date = model.Date,
            };
            await _messDbContext.AddAsync(entity);
            await _messDbContext.SaveChangesAsync();
            return new ApiResponse<ExpenseResponseModel>
            {
                Succeeded = true,
                Message = "Expense  added successfully.",
                Description = "Expense  added successfully."

            };
        }
		public async Task<ApiResponse<ExpenseResponseModel>> AddMonthlyAsync(ExpenseRequestModel model)
		{
            if (model.ExpenseHeadId == null || model.ExpenseHeadId == 0)
            {
                var existingExpense = await _messDbContext.Expenses
                                        .FirstOrDefaultAsync(x =>
                                        x.Date.Value.Year == model.Date.Year &&
                                        x.Date.Value.Month == model.Date.Month);

                if (existingExpense == null)
                {
                    var entity = new ExpenseEntity
                    {
                        Amount = model.Amount,
                        Date = model.Date,
                        Description = model.Description,
                        Status = ClosingStatus.Open,
                    };
                    await _messDbContext.AddAsync(entity);
                    await _messDbContext.SaveChangesAsync();
                    return new ApiResponse<ExpenseResponseModel>
                    {
                        Succeeded = true,
                        Message = "Expense  added successfully.",
                        Description = "Expense  added successfully."

                    };
                }
                else
                {
                    return new ApiResponse<ExpenseResponseModel>
                    {
                        Succeeded = false,
                        IsError = true,
                        Message = "Monthly expense already exists for this month.",
                        Description = "Monthly expense already exists for this month."
                    };
                }
            }
			else
			{
				return new ApiResponse<ExpenseResponseModel>
				{
					Succeeded = false,
					IsError = true,
					Message = "Monthly expense cannot be added with specific expense head.",
					Description = "Monthly expense cannot be added with specific expense head."
				};
			}
		}
		public async Task<ApiResponse<bool>> AddMonthlyClosingAsync(int id)
		{
            var repo = _unitOfWork.GetRepository<ExpenseEntity>();
			// Check if the expense with the given ID exists and is open
			var existingExpense = await repo.FirstOrDefaultAsync(x => x.Id == id && x.Status == ClosingStatus.Open);
            if (existingExpense != null)
            {

                var totalexpensAmount = existingExpense.Amount;

                var totalAttendace = await _messDbContext.Attendance
					.Where(x => x.Date.Year == existingExpense.Date.Value.Year &&
								x.Date.Month == existingExpense.Date.Value.Month)
					.CountAsync();

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
					predicate: x => x.Role.Name.ToLower() == "student",
					include: x => x.Include(u => u.Role)
				);

				foreach (var student in Users)
                {
                    var totalStudenAttendance = await _messDbContext.Attendance
						.Where(x => x.ApplicationUserId == student.Id &&
									x.Date.Year == existingExpense.Date.Value.Year &&
									x.Date.Month == existingExpense.Date.Value.Month)
						.CountAsync();
                    var UserBalance = Convert.ToDecimal(student.Balance) - (totalStudenAttendance * mealPerHead * 2); // Assuming 2 meals per day
					var userAccount = new AccountsEntity
                    {
                        ApplicationUserId = student.Id,
                        Credit = 0,
                        Debit = totalStudenAttendance * mealPerHead * 2, // Assuming 2 meals per day
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
		public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _messDbContext.Expenses
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _messDbContext.Remove(entity);
                await _messDbContext.SaveChangesAsync();

                return new ApiResponse<bool>
                {
                    Description = "Successfully Deleted!",
                    Message = "Successfully Deleted",
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

        public async Task<ApiResponse<ExpenseResponseModel>> GetByIdAsync(int id)
        {
            var entity = await _messDbContext.Expenses.Include(x=> x.ExpenseHead)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return new ApiResponse<ExpenseResponseModel>
                {
                    Succeeded = false,
                    IsError = true,
                    Description = "Expense not found.",
                    Message = "Expense not found."
                };
            }
            return new ApiResponse<ExpenseResponseModel>
            {
                Data = new ExpenseResponseModel
                {
                    Id = entity.Id,
                    ExpenseHeadName = entity.ExpenseHead?.Name,
					ExpenseHeadId = entity.ExpenseHeadId,
					Description = entity.Description,
					Amount = entity.Amount,
					Date = entity.Date
				},
                Succeeded = true,
                Message = "Expense retrieved successfully.",
                Description = "Expense retrieved successfully.",
            };
        }

        public async Task<PaginatedResponseModel<ExpenseResponseModel>> GetAsync(PaginationParams paginationParams)
        {
            try
            {
                var query = _messDbContext.Expenses.AsQueryable();
                if (!string.IsNullOrEmpty(paginationParams.Search))
                {
                    query = query.Where(x => x.Description.ToLower().Contains(paginationParams.Search) 
                    || x.ExpenseHead.Name.ToLower().Contains(paginationParams.Search));
                }
                var totalCount = await query.CountAsync();
                var result = await query
                    .Select(x => new ExpenseResponseModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Amount = x.Amount,
                        Date = x.Date,
                        ExpenseHeadName = x.ExpenseHead.Name,
                        ExpenseHeadId = x.ExpenseHeadId,
                        
                    })
                    .ToListAsync();

                return new PaginatedResponseModel<ExpenseResponseModel>()
                {
                    TotalRecords = totalCount,
                    Records = result,
                    PaginationParam = paginationParams,

                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		public async Task<PaginatedResponseModel<ExpenseResponseModel>> GetMonthlyAsync(PaginationParams paginationParams)
		{
			try
			{
				var query = _messDbContext.Expenses.Where(x=> x.ExpenseHeadId == 0 || x.ExpenseHeadId == null).AsQueryable();
				if (!string.IsNullOrEmpty(paginationParams.Search))
				{
					query = query.Where(x => x.Description.ToLower().Contains(paginationParams.Search)
                    
                    );
				}
				var totalCount = await query.CountAsync();
				var result = await query
					.Select(x => new ExpenseResponseModel
					{
						Id = x.Id,
						Description = x.Description,
						Amount = x.Amount,
						Date = x.Date,
						ExpenseHeadName = x.ExpenseHead.Name,
						ExpenseHeadId = x.ExpenseHeadId,
                        Status = x.Status == null? null :x.Status

					})
					.ToListAsync();



				return new PaginatedResponseModel<ExpenseResponseModel>()
				{
					TotalRecords = totalCount,
					Records = result,
					PaginationParam = paginationParams,

				};
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseRequestModel model)
        {

            var existance = await _messDbContext.Expenses
                .FirstOrDefaultAsync(x => x.Id == id);
            if (existance != null)
            {
                existance.Description = model.Description;
                existance.Amount = model.Amount;
                existance.ExpenseHeadId = model.ExpenseHeadId;
                existance.Date = model.Date;
                existance.UpdatedOn = DateTime.Now;
                _messDbContext.Update(existance);
                await _messDbContext.SaveChangesAsync();
                return new ApiResponse<bool>
                {
                    Succeeded = true,
                    Data = true,
                    Message = "Expense updated successfully.",
                    Description = "Expense updated successfully.",

                };
            }
            return new ApiResponse<bool>
            {
                Succeeded = false,
                IsError = true,
                Description = $"No data found.",
                Message = $"No data found.",
            };
        }
    }
}
