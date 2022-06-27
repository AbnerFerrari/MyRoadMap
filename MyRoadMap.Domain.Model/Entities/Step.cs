using MyRoadMap.Domain.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Domain.Model.Entities
{
    public class Step : Entity
    {
        public Step()
        {

        }

        public Step(string description)
        {
            Description = description;
        }

        [Required]
        public string Description { get; set; }

        public bool Done { get; set; }

        public RoadMap RoadMap { get; set; }

        public int Index { get; set; }
    }
}
