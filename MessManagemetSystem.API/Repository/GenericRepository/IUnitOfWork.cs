namespace MessManagemetSystem.API.Repository.GenericRepository
{
	public interface IUnitOfWork : IDisposable
	{
		int Commit();
		Task<int> CommitAsync();
		IGenericRepository<T> GetRepository<T>() where T : class;

	}
}
