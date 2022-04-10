using MyRoadmap.Domain.Entities.Base;
using System.Linq.Expressions;

namespace MyRoadmap.Infrastructure.Interfaces
{
    public interface IQueryRepository <T> where T : EntityBase
    {
        Task<T> Get(long id);
        List<T> GetAll(Expression<Func<T, bool>> @filter);
    }
}
