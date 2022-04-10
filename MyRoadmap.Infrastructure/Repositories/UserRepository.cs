using MyRoadmap.Domain.Entities;

namespace MyRoadmap.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly MyRoadmapContext _context;
        public UserRepository(MyRoadmapContext context)
        {
            _context = context;
        }

        public async Task Insert(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(long id)
        {
            var user = await _context.Users.FindAsync(id);
                
            return user;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
