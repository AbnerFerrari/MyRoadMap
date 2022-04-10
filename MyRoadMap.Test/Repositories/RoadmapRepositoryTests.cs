using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadmap.Domain.Entities;
using MyRoadmap.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoadMap.Test.Repositories
{
    [TestClass]
    public class RoadmapRepositoryTests
    {
        private static IRepository<Roadmap> _repository;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _repository = Startup.ServiceProvider.GetService<IRepository<Roadmap>>();
        }

        [TestMethod]
        public async Task Get()
        {
            await _repository.Get(1);
        }
    }
}
