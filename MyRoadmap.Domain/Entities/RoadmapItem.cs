using MyRoadmap.Domain.Entities.Base;

namespace MyRoadmap.Domain.Entities
{
    public class RoadmapItem : EntityBase
    {
        public string Description { get; set; }

        public RoadmapItem LastRequiredItem { get; set; }
    }
}
