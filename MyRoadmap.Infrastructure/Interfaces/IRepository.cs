using MyRoadmap.Domain.Entities.Base;
using MyRoadmap.Domain.Interfaces;

namespace MyRoadmap.Infrastructure.Interfaces
{
    public interface IRepository<T> : IQueryRepository<T> where T : EntityBase, IAggregateRoot    
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
