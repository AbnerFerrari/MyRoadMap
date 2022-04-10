using MyRoadmap.Domain.Entities.Base;
using MyRoadmap.Domain.Interfaces;

namespace MyRoadmap.Domain.Entities
{
    public class Roadmap : EntityBase, IAggregateRoot
    {
        public IList<RoadmapItem> RoadmapItems { get; set; }

        public int PriorityLevel { get; set; }
    }
}
