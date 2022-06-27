using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyRoadMap.Domain.Model;
using System.Reflection;

namespace MyRoadMap.Infrastructure
{
    internal class MyRoadMapContextFactory : IDesignTimeDbContextFactory<MyRoadMapContext>
    {
        public MyRoadMapContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();

            var appSettings = new AppSettings
            {
                //Comes from User-Secrets. See: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows
                ConnectionString = configuration["ConnectionString"]
            };

            var optionsBuilder = new DbContextOptionsBuilder<MyRoadMapContext>();

            optionsBuilder
                .UseNpgsql(appSettings.ConnectionString)
                .UseSnakeCaseNamingConvention();

            return new MyRoadMapContext(optionsBuilder.Options);
        }
    }
}
