using MyRoadmap.Domain.Entities.Base;

namespace MyRoadmap.Infrastructure.Interfaces
{
    public interface IQueryRepository <T> where T : EntityBase
    {
        Task<T> Get(long id);
    }
}
