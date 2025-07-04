using MessManagementSystem.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessManagemetSystem.API.Helper
{
	public static class PaginatedHelper<T>
	{
		public async static Task<List<T>> GetPaginatedRecored(IQueryable<T> query, Expression<Func<T, object>> orderByExpression, PaginationParams dtParams)
		{
			var paginatedResult = await query
				.OrderByDescending(orderByExpression)
						.Skip((dtParams.PageNumber) * dtParams.PageSize)
						.Take(dtParams.PageSize).ToListAsync();

			return paginatedResult;

		}
		public async static Task<List<T>> GetPaginatedRecored(IEnumerable<T> query, Expression<Func<T, object>> orderByExpression, PaginationParams dtParams)
		{
			var paginatedResult = query
						.Skip((dtParams.PageNumber) * dtParams.PageSize)
						.Take(dtParams.PageSize).ToList();

			return paginatedResult;

		}

		public async static Task<List<T>> GetPaginatedRecored(IQueryable<T> query)
		{
			var paginatedResult = await query.Take(8).ToListAsync();
			return paginatedResult;
		}
		public async static Task<List<T>> GetPaginatedRecored(IEnumerable<T> query)
		{
			var paginatedResult = query.Take(8).ToList();
			return paginatedResult;
		}

	}
}
