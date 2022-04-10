using MyRoadmap.Domain.Entities.Base;

namespace MyRoadmap.Domain.Entities
{
    public class RoadmapItem : EntityBase
    {
        public string Description { get; set; }

        public Roadmap LastRequiredItem { get; set; }
    }
}
