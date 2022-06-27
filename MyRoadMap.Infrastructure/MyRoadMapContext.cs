using Microsoft.EntityFrameworkCore;
using MyRoadMap.Domain.Model.Entities;

namespace MyRoadMap.Infrastructure
{
    public class MyRoadMapContext : DbContext
    {
        public MyRoadMapContext(DbContextOptions<MyRoadMapContext> options) : base(options)
        { }

        public DbSet<RoadMap> RoadMaps { get; set; }

        public DbSet<Step> Steps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<RoadMap>()
                .Property(x => x.Description)
                .IsRequired();

            modelBuilder.Entity<Step>()
                .Property(x => x.Description)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
