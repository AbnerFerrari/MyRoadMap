using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRoadMap.Domain.Model.Entities;
using MyRoadMap.Domain.Model.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Test.Validation
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateRecursively()
        {
            var roadMap = new RoadMap("");
            roadMap.Steps.AddLast(new Step(""));
            roadMap.Steps.AddLast(new Step(""));

            var validationResults = new List<ValidationResult>();
            roadMap.ValidateAnnotations(validationResults, new HashSet<object>());

            Assert.IsTrue(validationResults.Count == 3);
        }
    }
}
