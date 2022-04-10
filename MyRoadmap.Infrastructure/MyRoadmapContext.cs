using Microsoft.EntityFrameworkCore;
using MyRoadmap.Domain;
using MyRoadmap.Domain.Entities;

namespace MyRoadmap.Infrastructure
{
    public class MyRoadmapContext : DbContext
    {
        public MyRoadmapContext(DbContextOptions<MyRoadmapContext> options) : base(options)
        { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<RoadmapItem> RoadmapItems { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
