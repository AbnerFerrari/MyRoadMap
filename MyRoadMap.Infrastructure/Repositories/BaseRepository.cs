using Microsoft.EntityFrameworkCore;
using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Model.Entities.Interfaces;
using MyRoadMap.Domain.Repositories;
using System.Linq.Expressions;

namespace MyRoadMap.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly MyRoadMapContext _context;
        public BaseRepository(MyRoadMapContext context)
        {
            _context = context;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> @filter)
        {
            return await _context.Set<T>().AnyAsync(@filter);
        }

        public async Task<bool> Any()
        {
            return await _context.Set<T>().AnyAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> @filter)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(@filter);
            return entity!;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> @filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
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