using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using System.Collections;

namespace API.Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly StoreContext _context;
		private Hashtable _repositories;
		public UnitOfWork(StoreContext context,Hashtable repositories)
		{
			_context = context;
			_repositories = repositories;
		}

		public async Task<int> Complete()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
		{
			if(_repositories==null)
				_repositories = new Hashtable();
			var type=typeof(TEntity).Name;
			if(!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(GenericRepository<>);
				var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
			}
			return (IGenericRepository<TEntity>)_repositories[type];
		}
	}
}
