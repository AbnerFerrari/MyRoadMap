using MyRoadmap.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoadmap.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public Topic TopicOfInterest { get; set; }

        public Roadmap Roadmap { get; set; }
    }
}
