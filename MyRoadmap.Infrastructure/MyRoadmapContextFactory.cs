using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyRoadmap.Domain;
using System.Reflection;

namespace MyRoadmap.Infrastructure
{
    internal class MyRoadmapContextFactory : IDesignTimeDbContextFactory<MyRoadmapContext>
    {
        public MyRoadmapContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();

            var appSettings = new AppSettings
            {
                ConnectionString = configuration["ConnectionString"]
            };

            var optionsBuilder = new DbContextOptionsBuilder<MyRoadmapContext>();
            
            return new MyRoadmapContext(optionsBuilder.Options, appSettings);
        }
    }
}
