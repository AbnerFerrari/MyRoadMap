using MyRoadmap.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoadmap.Domain.Entities
{
    public class Topic : EntityBase
    {
        public string Description { get; set; }

        public string Goal { get; set; }
    }
}
