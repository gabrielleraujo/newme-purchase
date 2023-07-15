using Microsoft.EntityFrameworkCore;
using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Repositories;

namespace Newme.Purchase.Infrastructure.Persistence.Repositories
{
    public abstract class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : Entity
	{
		protected readonly PurchaseCommandContext _context;
		protected DbSet<T> _dbSet;

        public BaseCommandRepository(PurchaseCommandContext dbContext)
        {
			_context = dbContext;
			_dbSet = _context.Set<T>();
        }

		public virtual async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

        public async Task AddRangeAsync(IList<T> entities)
		{
			await _dbSet.AddRangeAsync(entities);
		}

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

		#region consulting
        public virtual async Task<TModel> FindByAsync<TModel>(Func<TModel, bool> predicate) where TModel : class
        {
            return _context.Set<TModel>().FirstOrDefault(predicate);
        }

        public async Task<List<TModel>> GetByAsync<TModel>(Func<TModel, bool> predicate) where TModel : class
        {
            return _context.Set<TModel>().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetItemsNotFound<TEntity>(IEnumerable<TEntity> items) where TEntity : Entity
        {
            var exists = _context.Set<T>().Where(x => items.Select(x => x.Id).Contains(x.Id)).ToList();
            return items.Where(x => !exists.Select(x => x.Id).Contains(x.Id));
        }

        public IEnumerable<Guid> GetIdsNotFound(IEnumerable<Guid> ids)
        {
            var exists = _context.Set<T>().Where(x => ids.Contains(x.Id)).Select(x => x.Id);
            return ids.Where(x => !exists.Contains(x));
        }
        #endregion
	}
}