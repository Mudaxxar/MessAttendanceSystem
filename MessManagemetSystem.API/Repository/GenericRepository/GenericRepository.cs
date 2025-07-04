using MessManagemetSystem.API.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MessManagemetSystem.API.Repository.GenericRepository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		internal MessDbContext context;
		internal DbSet<TEntity> dbSet;

		public GenericRepository(MessDbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}
		public async Task<IEnumerable<TEntity>> GetIncludeAsync(
										Expression<Func<TEntity, bool>> predicate = null,
										Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
										Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
										bool disableTracking = true)
		{
			IQueryable<TEntity> query = dbSet;

			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}


		public async Task<TEntity> FirstOrDefaultIncludAsync(
													   Expression<Func<TEntity, bool>> filter = null,
													   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
													   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (include != null)
			{
				query = include(query);
			}

			if (orderBy != null)
			{
				return await orderBy(query).FirstOrDefaultAsync();
			}
			else
			{
				return await query.FirstOrDefaultAsync();
			}
		}
		public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
														Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}
		public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null,
														Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return await orderBy(query).FirstOrDefaultAsync();
			}
			else
			{
				return await query.FirstOrDefaultAsync();
			}
		}
		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
														Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).FirstOrDefault();
			}
			else
			{
				return query.FirstOrDefault();
			}
		}
		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return await query.AnyAsync();

		}
		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}
			return await query.CountAsync();
		}

		public async Task<TEntity> GetByIdAsync(object id)
		{
			return await dbSet.FindAsync(id);
		}
		public TEntity GetById(object id)
		{
			return dbSet.Find(id);
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await dbSet.AddAsync(entity);
			return entity;
		}
		public TEntity Add(TEntity entity)
		{
			dbSet.Add(entity);
			return entity;
		}

		public void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public async Task UpdateAsync(int Id, TEntity entityToUpdate)
		{
			var checkObj = await GetByIdAsync(Id);
			if (checkObj != null)
			{
				context.Entry(checkObj).State = EntityState.Detached;
			}
			var x = dbSet.Attach(entityToUpdate);

			context.Entry(entityToUpdate).State = EntityState.Modified;
		}
		public void Update(TEntity entityToUpdate)
		{
			var x = dbSet.Attach(entityToUpdate);

			context.Entry(entityToUpdate).State = EntityState.Modified;
		}
		public IQueryable<TEntity> GetAll()
		{
			IQueryable<TEntity> query = dbSet;
			return query;
		}

	}
}

