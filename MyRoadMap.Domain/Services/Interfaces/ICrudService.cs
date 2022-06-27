using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Model.Entities.Interfaces;

namespace MyRoadMap.Domain.Services.Interfaces
{
    public interface ICrudService<T> : IQueryService<T> where T : Entity, IAggregateRoot
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
