using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Model.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Domain.Model.Entities
{
    public class RoadMap : Entity, IAggregateRoot
    {
        public RoadMap()
        {

        }

        public RoadMap(string description)
        {
            Description = description;
            Steps = new LinkedList<Step>();
        }

        [Required]
        public string Description { get; set; }

        public LinkedList<Step>? Steps { get; set; }
    }
}
