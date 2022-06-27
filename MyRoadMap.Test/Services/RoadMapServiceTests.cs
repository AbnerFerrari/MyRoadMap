using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadMap.Domain.Model.Entities;
using MyRoadMap.Domain.Model.Validation;
using MyRoadMap.Domain.Services.Interfaces;

namespace MyRoadMap.Test.Services
{
    [TestClass]
    public class RoadMapServiceTests
    {
        private static IRoadMapService service;

        [ClassInitialize]
        public static void Start(TestContext context)
        {
            service = Startup.ServiceProvider.GetService<IRoadMapService>();
        }

        [TestMethod]
        public async Task Get()
        {
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            await service.Insert(roadMap);

            roadMap = await service.Get(x => x.Id == roadMap.Id);

            Assert.IsNotNull(roadMap);
        }

        [TestMethod]
        public async Task Insert()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            //Act
            await service.Insert(roadMap);

            //Assert
            Assert.IsTrue(roadMap.Id > 0);
        }

        [TestMethod]
        public async Task Insert_ExistingEntity_ShouldThrowValidationException()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            //Act
            await service.Insert(roadMap);
            var duplicatedEntity = new RoadMap { Id = roadMap.Id };

            //Assert
            await Assert.ThrowsExceptionAsync<ValidationException>(async () => await service.Insert(duplicatedEntity));
        }

        [TestMethod]
        public async Task Insert_WithEmptyDescription_ShouldThrowValidationException()
        {
            //Arrange
            var roadMap = new RoadMap("");

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<ValidationException>(async () => await service.Insert(roadMap));
        }

        [TestMethod]
        public async Task Insert_WithInvalidSteps_ShouldThrowValidationException()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");
            roadMap.Steps.AddLast(new Step(""));

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<ValidationException>(async () => await service.Insert(roadMap));
        }

        [TestMethod]
        public async Task Insert_With_Steps()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            roadMap.Steps.AddLast(new Step("Programing Logic"));

            //Act
            await service.Insert(roadMap);

            //Assert
            Assert.IsTrue(roadMap.Id > 0);
            Assert.IsTrue(roadMap.Steps.Select(x => x.Id).All(x => x > 0));
        }

        [TestMethod]
        public async Task Update()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            await service.Insert(roadMap);

            roadMap = await service.Get(x => x.Id == roadMap.Id);
            var newDescription = "Desenvolvedor Front-End";
            //Act
            roadMap.Description = newDescription;

            await service.Update(roadMap);

            roadMap = await service.Get(x => x.Id == roadMap.Id);

            //Assert
            Assert.IsTrue(roadMap.Description == newDescription);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Arrange

            var roadMap = new RoadMap("Desenvolvedor Back-End");

            await service.Insert(roadMap);

            roadMap = await service.Get(x => x.Id == roadMap.Id);
            var userId = roadMap.Id;

            //Act
            await service.Delete(roadMap);

            roadMap = await service.Get(x => x.Id == userId);

            //Assert
            Assert.IsNull(roadMap);
        }

        [TestMethod]
        public async Task Add_Step()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");

            var firstStep = new Step("Programing Logic");
            roadMap.Steps.AddLast(firstStep);
            await service.Insert(roadMap);

            //Act
            var step = new Step("Programing Logic");
            roadMap.Steps.AddLast(step);

            await service.Update(roadMap);

            //Assert
            Assert.IsTrue(step.Id > 0);
            Assert.IsTrue(roadMap.Steps.Find(firstStep).Next.Value.Id == step.Id);
            Assert.IsTrue(roadMap.Steps.Find(step).Previous.Value.Id == firstStep.Id);
        }

        [TestMethod]
        public async Task Remove_Step()
        {
            //Arrange
            var roadMap = new RoadMap("Desenvolvedor Back-End");
            var firstStep = new Step("Programing Logic");
            var secondStep = new Step("Data Structure");
            var thirdStep = new Step("Algorithms");

            roadMap.Steps.AddLast(firstStep);
            roadMap.Steps.AddLast(secondStep);
            roadMap.Steps.AddLast(thirdStep);
            await service.Insert(roadMap);

            //Act
            roadMap.Steps.Remove(secondStep);
            await service.Update(roadMap);

            //Assert
            var roadMapUpdated = await service.Get(x => x.Id == roadMap.Id);
            Assert.IsTrue(roadMapUpdated.Steps.Count == 2);
            var firstNode = roadMapUpdated.Steps.Find(firstStep);
            var thirdNode = roadMapUpdated.Steps.Find(thirdStep);
            Assert.IsTrue(firstNode.Next.Value.Id == thirdStep.Id);
            Assert.IsTrue(thirdNode.Previous.Value.Id == firstStep.Id);
        }
    }
}
