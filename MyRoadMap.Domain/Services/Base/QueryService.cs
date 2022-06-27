using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Repositories;
using MyRoadMap.Domain.Services.Interfaces;
using System.Linq.Expressions;

namespace MyRoadMap.Domain.Services.Base
{
    public class QueryService<T> : IQueryService<T> where T : Entity
    {
        protected readonly IRepository<T> Repository;

        public QueryService(IRepository<T> repository)
        {
            Repository = repository;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> @filter)
        {
            return await Repository.Any(@filter);
        }

        public async Task<bool> Any()
        {
            return await Repository.Any();
        }

        public async Task<T> Get(Expression<Func<T, bool>> @filter)
        {
            return await Repository.Get(@filter);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> @filter)
        {
            return Repository.GetAll(@filter);
        }

        public Task<List<T>> GetAll()
        {
            return Repository.GetAll();
        }
    }
}