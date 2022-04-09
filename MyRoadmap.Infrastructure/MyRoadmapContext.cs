using Microsoft.EntityFrameworkCore;
using MyRoadmap.Domain;
using MyRoadmap.Domain.Entities;

namespace MyRoadmap.Infrastructure
{
    public class MyRoadmapContext : DbContext
    {
        public MyRoadmapContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            AppSettings = new AppSettings
            {
                ConnectionString = Path.Join(path, "myRoadmap.db")
            };
        }

        public AppSettings AppSettings { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapItem> RoadmapItems { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={AppSettings.ConnectionString}");
    }
}
