using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadmap.Domain.Entities;
using MyRoadmap.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace MyRoadMap.Test.Repositories
{
    [TestClass]
    public class TopicRepositoryTest
    {
        private static IRepository<Topic> _repository;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _repository = Startup.ServiceProvider.GetService<IRepository<Topic>>();
        }

        [TestMethod]
        public async Task Insert()
        {
            var entity = new Topic
            {
                Goal = "Back-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };
            await _repository.Insert(entity);

            Assert.IsTrue(entity.Id != 0);
        }

        [TestMethod]
        public async Task GetById()
        {
            var entity = new Topic
            {
                Goal = "Back-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };
            await _repository.Insert(entity);

            var fromDb = await _repository.Get(entity.Id);

            Assert.IsTrue(fromDb is not null);
        }

        [TestMethod]
        public async Task Get_WithFilter()
        {
            var entity = new Topic
            {
                Goal = "Back-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };

            var entity2 = new Topic
            {
                Goal = "Fron-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };

            await _repository.Insert(entity);
            await _repository.Insert(entity2);

            var fromDb = _repository.GetAll(x => x.Id >= 0);

            Assert.IsTrue(fromDb.Count > 1);
        }

        [TestMethod]
        public async Task Update()
        {
            var entity = new Topic
            {
                Goal = "Back-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };
            await _repository.Insert(entity);
            
            entity.Goal = "Front-End Developer";

            await _repository.Update(entity);

            var fromDb = await _repository.Get(entity.Id);

            Assert.IsTrue(fromDb.Goal.Equals(entity.Goal));
        }

        [TestMethod]
        public async Task Delete()
        {
            var entity = new Topic
            {
                Goal = "Back-End Developer",
                Description = "Be able to build a brand new application and publish it to the world"
            };
            await _repository.Insert(entity);

            var fromDb = await _repository.Get(entity.Id);

            if (fromDb is null)
                Assert.Fail();

            await _repository.Delete(entity);

            fromDb = await _repository.Get(entity.Id);

            Assert.IsTrue(fromDb is null);
        }
    }
}
