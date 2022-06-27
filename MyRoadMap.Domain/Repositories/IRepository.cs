using MyRoadMap.Domain.Model.Entities.Base;
using System.Linq.Expressions;

namespace MyRoadMap.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> Any(Expression<Func<T, bool>> @filter);
        Task<bool> Any();
        Task Delete(T entity);
        Task Insert(T entity);
        Task Update(T entity);
        Task<T> Get(Expression<Func<T, bool>> @filter);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> @filter);
    }
}
