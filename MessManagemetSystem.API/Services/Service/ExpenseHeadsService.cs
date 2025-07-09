using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Services.Service
{
	public class ExpenseHeadsService : IExpenseHeadsService
	{
		private readonly MessDbContext _messDbContext;
		public ExpenseHeadsService(MessDbContext messDbContext)
		{
			this._messDbContext = messDbContext;
		}
		public async Task<ApiResponse<ExpenseHeadsResponseModel>> AddAsync(ExpenseHeadsRequestModel model)
		{
			var existance = async () => await _messDbContext.ExpenseHeads
				.AnyAsync(x => x.Name.Equals(model.Name.ToLower()));
			if (await existance())
			{
				return new ApiResponse<ExpenseHeadsResponseModel>
				{
					Succeeded = false,
					IsError = true,
					Description = $"Expense head -{model.Name} already exists.",
					Message = "Expense head -{model.Name} already exists.",

				};
			}
			var expenseHead = new ExpenseHeadEntity
			{
				Name = model.Name,
				CreatedOn = DateTime.UtcNow
			};
			_messDbContext.Add(expenseHead);
			_messDbContext.SaveChanges();
			return new ApiResponse<ExpenseHeadsResponseModel>
			{
				Succeeded = true,
				Data = new ExpenseHeadsResponseModel
				{
					Name = expenseHead.Name,
					Id = expenseHead.Id,
				},
				Message = "Expense head added successfully.",
				Description = "Expense head added successfully."

			};
		}

		public async Task<ApiResponse<bool>> DeleteAsync(int id)
		{
			var expenseHead = await _messDbContext.ExpenseHeads
				.FirstOrDefaultAsync(x => x.Id == id);
			if (expenseHead != null)
			{
				_messDbContext.ExpenseHeads.Remove(expenseHead);
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

		public async Task<ApiResponse<ExpenseHeadsResponseModel>> GetByIdAsync(int id)
		{
			var expenseHead = await _messDbContext.ExpenseHeads
				.FirstOrDefaultAsync(x => x.Id == id);
			if (expenseHead == null)
			{
				return new ApiResponse<ExpenseHeadsResponseModel>
				{
					Succeeded = false,
					IsError = true,
					Description = "Expense head not found.",
					Message = "Expense head not found."
				};
			}
			return new ApiResponse<ExpenseHeadsResponseModel>
			{
				Succeeded = true,
				Data = new ExpenseHeadsResponseModel
				{
					Id = expenseHead.Id,
					Name = expenseHead.Name,
				},
				Message = "Expense head retrieved successfully."
			};
		}

		public async Task<PaginatedResponseModel<ExpenseHeadsResponseModel>> GetAsync(PaginationParams paginationParams)
		{
			try {
				var pageNumber = paginationParams.PageNumber > 0 ? paginationParams.PageNumber : 1;
				var pageSize = paginationParams.PageSize > 0 ? paginationParams.PageSize : 10;
				var query = _messDbContext.ExpenseHeads.AsQueryable();
			if (!string.IsNullOrEmpty(paginationParams.Search))
			{
				query = query.Where(x => x.Name.ToLower().Contains(paginationParams.Search));
			}
			var totalCount = await query.CountAsync();
			var expenseHeads = await query
				.Skip((pageNumber - 1) * paginationParams.PageSize)
				.Take(pageSize)
				.Select(x => new ExpenseHeadsResponseModel
				{
					Id = x.Id,
					Name = x.Name,
				})
				.ToListAsync();



			return new PaginatedResponseModel<ExpenseHeadsResponseModel>()
			{
				TotalRecords = totalCount,
				Records = expenseHeads,
				PaginationParam = paginationParams,

			};
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<ApiResponse<bool>> UpdateAsync(int id, ExpenseHeadsRequestModel model)
		{
			var existance = async () => await _messDbContext.ExpenseHeads
				.AnyAsync(x => x.Name.Equals(model.Name.ToLower()) && x.Id != id);
			if (await existance())
			{
					return new ApiResponse<bool>
					{
						Succeeded = false,
						IsError = true,
						Description = $"Expense{model.Name} head already exists.",
						Message = $"Expense head {model.Name} already exists."
					};
				
			}
			var expenseHead = await _messDbContext.ExpenseHeads
				.FirstOrDefaultAsync(x => x.Id == id);
			if (expenseHead != null)
			{
				expenseHead.Name = model.Name;
				_messDbContext.Update(expenseHead);
				await _messDbContext.SaveChangesAsync();
				return new ApiResponse<bool>
				{
					Succeeded = true,
					Data = true,
					Message = "Expense head updated successfully.",
					Description = "Expense head updated successfully.",

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

        public async Task<List<ExpenseHeadsResponseModel>> GetAsync()
        {

            var query = _messDbContext.ExpenseHeads.AsQueryable();
            var totalCount = await query.CountAsync();
            var result = await query

                .Select(x => new ExpenseHeadsResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
            return result;



        }
    }
}
