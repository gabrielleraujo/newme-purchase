using Newme.Purchase.Domain.Models.Abstracts;

namespace Newme.Purchase.Domain.Repositories
{
    public interface IBaseCommandRepository<T> where T : Entity
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IList<T> entities);
		Task<bool> CommitAsync();

		#region consulting
		Task<TModel> FindByAsync<TModel>(Func<TModel, bool> predicate) where TModel : class;
		Task<List<TModel>> GetByAsync<TModel>(Func<TModel, bool> predicate) where TModel : class;
		public Task<IEnumerable<TEntity>> GetItemsNotFound<TEntity>(IEnumerable<TEntity> items) where TEntity : Entity;
        public IEnumerable<Guid> GetIdsNotFound(IEnumerable<Guid> ids);
		#endregion
	}
}