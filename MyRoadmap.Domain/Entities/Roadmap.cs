using MyRoadmap.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoadmap.Domain.Entities
{
    public class Roadmap : EntityBase
    {
        public IList<RoadmapItem> RoadmapItem { get; set; }

        public int PriorityLevel { get; set; }
    }
}
