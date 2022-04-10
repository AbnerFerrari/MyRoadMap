using Microsoft.EntityFrameworkCore;
using MyRoadmap.Domain;
using MyRoadmap.Domain.Entities;

namespace MyRoadmap.Infrastructure
{
    public class MyRoadmapContext : DbContext
    {
        public MyRoadmapContext(DbContextOptions<MyRoadmapContext> options, AppSettings appSettings) : base(options)
        {
            _appSettings = appSettings;
        }

        private readonly AppSettings _appSettings;

        public DbSet<Topic> Topics { get; set; }
        public DbSet<RoadmapItem> RoadmapItems { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(_appSettings.ConnectionString).UseSnakeCaseNamingConvention();
    }
}
