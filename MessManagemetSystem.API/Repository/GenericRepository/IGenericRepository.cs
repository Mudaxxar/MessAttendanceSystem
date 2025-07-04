using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MessManagemetSystem.API.Repository.GenericRepository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
														Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														string includeProperties = "");
		public Task<IEnumerable<TEntity>> GetIncludeAsync(
										Expression<Func<TEntity, bool>> predicate = null,
										Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
										Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
										bool disableTracking = true);
		public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null,
													   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
													   string includeProperties = "");
		public Task<TEntity> FirstOrDefaultIncludAsync(Expression<Func<TEntity, bool>> filter = null,
													   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
													   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
													   string includeProperties = "");

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
		public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
		public Task<TEntity> GetByIdAsync(object id);
		public TEntity GetById(object id);
		public Task<TEntity> AddAsync(TEntity entity);
		public TEntity Add(TEntity entity);
		public void Delete(object id);
		public Task UpdateAsync(int Id, TEntity entityToUpdate);
		public void Update(TEntity entityToUpdate);
		public IQueryable<TEntity> GetAll();


	}
}
