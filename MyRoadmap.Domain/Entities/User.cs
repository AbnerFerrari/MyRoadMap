using MyRoadmap.Domain.Entities.Base;
using MyRoadmap.Domain.Interfaces;

namespace MyRoadmap.Domain.Entities
{
    public class User : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public Topic TopicOfInterest { get; set; }

        public Roadmap Roadmap { get; set; }
    }
}
