using MyRoadMap.Domain.Model.Entities.Base;
using System.Linq.Expressions;

namespace MyRoadMap.Domain.Services.Interfaces
{
    public interface IQueryService<T> where T : Entity
    {
        Task<bool> Any(Expression<Func<T, bool>> @filter);
        Task<bool> Any();
        Task<T> Get(Expression<Func<T, bool>> @filter);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> @filter);
    }
}
