using MyRoadMap.Domain.Model.Entities.Base;
using System.Linq.Expressions;

namespace MyRoadMap.Domain.Repositories
{
    public interface IQueryRepository<T> where T : Entity
    {
        Task<T> Get(long id);
        List<T> GetAll(Expression<Func<T, bool>> @filter);
    }
}
