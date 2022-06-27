using MyRoadMap.Domain.Model.Entities;
using MyRoadMap.Domain.Repositories;
using MyRoadMap.Domain.Services.Base;
using MyRoadMap.Domain.Services.Interfaces;
using MyRoadMap.Domain.Validators.Base;

namespace MyRoadMap.Domain.Services
{
    public class RoadMapService : CrudService<RoadMap>, IRoadMapService
    {
        public RoadMapService(IRepository<RoadMap> repository, Validator<RoadMap> validator) : base(repository, validator)
        {
        }
    }
}
