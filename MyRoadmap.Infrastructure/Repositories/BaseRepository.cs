using MyRoadmap.Domain.Entities.Base;
using MyRoadmap.Domain.Interfaces;
using MyRoadmap.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace MyRoadmap.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase, IAggregateRoot
    {
        private readonly MyRoadmapContext _context;
        public BaseRepository(MyRoadmapContext context)
        {
            _context = context;
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(long id)
        {
            var entity = await _context.FindAsync<T>(id);
            
            return entity;
        }

        public List<T> GetAll(Expression<Func<T, bool>> @filter)
        {
            var entities = _context.Set<T>().Where(filter);
            
            return entities.ToList();
        }

        public async Task Insert(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
