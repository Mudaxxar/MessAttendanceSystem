using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MessManagemetSystem.API.Services.Service
{
	public class AccountsService : IAccountsService
	{
		private readonly MessDbContext _dbContext;
        public AccountsService(MessDbContext messDbContext)
        {
			_dbContext = messDbContext;
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
	}
}
