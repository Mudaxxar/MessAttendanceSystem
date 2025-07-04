using MessManagemetSystem.API.DbContext;

namespace MessManagemetSystem.API.Repository.GenericRepository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MessDbContext _dbContext;
		private Dictionary<Type, object> _repos;
		public UnitOfWork(MessDbContext atlanticStarDbContext)
		{
			_dbContext = atlanticStarDbContext;
		}
		public int Commit()
		{
			return _dbContext.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
		public IGenericRepository<T> GetRepository<T>() where T : class
		{
			if (_repos == null)
			{
				_repos = new Dictionary<Type, object>();
			}
			var type = typeof(T);
			if (!_repos.ContainsKey(type))
			{
				_repos[type] = new GenericRepository<T>(_dbContext);
			}
			return (IGenericRepository<T>)_repos[type];
		}




		#region IDisposible

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		#endregion
	}
}
