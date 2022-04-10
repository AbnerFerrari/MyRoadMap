using MyRoadmap.Domain.Entities.Base;
using MyRoadmap.Domain.Interfaces;

namespace MyRoadmap.Domain.Entities
{
    public class Topic : EntityBase, IAggregateRoot
    {
        public string Description { get; set; }

        public string Goal { get; set; }
    }
}
