using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadMap.Domain.Model;
using MyRoadMap.Domain.Repositories;
using MyRoadMap.Domain.Services;
using MyRoadMap.Domain.Services.Base;
using MyRoadMap.Domain.Services.Interfaces;
using MyRoadMap.Domain.Validators.Base;
using MyRoadMap.Infrastructure;
using MyRoadMap.Infrastructure.Repositories;
using MyRoadMap.Test.Util;
using System.IO;

namespace MyRoadMap.Test
{
    [TestClass]
    public class Startup
    {
        public static ServiceProvider ServiceProvider { get; set; }
        private static AppSettings _appSettings;
        private static MyRoadMapContext _myRoadMapContext;

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

            if (integratedTest)
            {
                services.AddDbContext<MyRoadMapContext>(options => options
                    .UseNpgsql(_appSettings.ConnectionString)
                    .UseSnakeCaseNamingConvention());
            }
            else
            {
                services.AddDbContext<MyRoadMapContext>(options => options.UseSqlite(_appSettings.ConnectionString));
            }

            services.AddTransient(typeof(Validator<>));
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IQueryService<>), typeof(QueryService<>));
            services.AddTransient(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddTransient(typeof(IRoadMapService), typeof(RoadMapService));

            ServiceProvider = services.BuildServiceProvider();

            _myRoadMapContext = ServiceProvider.GetService<MyRoadMapContext>();

            _myRoadMapContext.Database.EnsureCreated();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            _myRoadMapContext.Database.EnsureDeleted();
        }
    }
}
