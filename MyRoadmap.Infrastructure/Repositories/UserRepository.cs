using MyRoadmap.Domain.Entities;

namespace MyRoadmap.Infrastructure.Repositories
{
    public class UserRepository
    {
        public void Insert(User user)
        {
            using var context = new MyRoadmapContext();

            context.Add(user);
            context.SaveChanges();
        }

        public User Get(long id)
        {
            using var context = new MyRoadmapContext();
            var user = context.Users
                .OrderBy(b => b.Id)
                .First();

            return user;
        }

        public void Update(User user)
        {
            using var context = new MyRoadmapContext();
            
            context.Users.Update(user);

            context.SaveChanges();
        }

        public void Delete(User user)
        {
            using var context = new MyRoadmapContext();

            context.Users.Remove(user);

            context.SaveChanges();
        }
    }
}
