using System.Linq.Expressions;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Application.Consulting.Repositories
{
    public interface IBaseQueryRepository<T> where T : ConsultingModel
    {
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T value);
        Task UpdateAsync<TValueUpdate>(Guid id, TValueUpdate newValue, Expression<Func<T, TValueUpdate>> expression);
    }
}
