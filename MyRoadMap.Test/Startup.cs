using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadmap.Infrastructure;
using MyRoadmap.Infrastructure.Interfaces;
using MyRoadmap.Infrastructure.Repositories;
using MyRoadmap.Test;
using MyRoadMap.Test.Util;
using System.IO;

namespace MyRoadMap.Test
{
    [TestClass]
    public class Startup
    {
        public static ServiceProvider ServiceProvider { get; set; }
        private static AppSettings _appSettings;
        private static MyRoadmapContext _myRoadmapContext;

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            const bool integratedTest = false;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(integratedTest ? $"appsettings.{TestEnvironment.IntegratedTest}.json" : "appsettings.json")
                .Build();

            _appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            var services = new ServiceCollection();

            if (_appSettings.TestEnvironment == TestEnvironment.IntegratedTest)
            {
                services.AddDbContext<MyRoadmapContext>(options => options
                    .UseNpgsql(_appSettings.ConnectionString)
                    .UseSnakeCaseNamingConvention());
            }
            else
            {
                services.AddDbContext<MyRoadmapContext>(options => options.UseSqlite(_appSettings.ConnectionString));
            }

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            ServiceProvider = services.BuildServiceProvider();

            _myRoadmapContext = ServiceProvider.GetService<MyRoadmapContext>();
            
            _myRoadmapContext.Database.EnsureCreated();

        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            _myRoadmapContext.Database.EnsureDeleted();
        }
    }
}
