using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadmap.Domain.Entities;
using MyRoadmap.Infrastructure.Repositories;

namespace MyRoadMap.Test
{
    [TestClass]
    public class UnitTest1
    {
        private static UserRepository _userRepository;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void CreateUser()
        {
            var user = new User { Name = "Teste" };
            _userRepository.Insert(user);
            var insertedUser = _userRepository.Get(user.Id);
        }
    }
}