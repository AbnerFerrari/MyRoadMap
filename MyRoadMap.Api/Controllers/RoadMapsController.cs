using Microsoft.AspNetCore.Mvc;
using MyRoadMap.Domain.Model.Entities;
using MyRoadMap.Domain.Services.Interfaces;

namespace MyRoadMap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadMapsController : ControllerBase
    {
        private IRoadMapService _roadMapService;
        private readonly ILogger<RoadMap> _logger;

        public RoadMapsController(IRoadMapService roadMapService, ILogger<RoadMap> logger)
        {
            _roadMapService = roadMapService;
            _logger = logger;
        }

        // GET: api/<RoadMapsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roadMapService.GetAll());
        }

        // GET api/<RoadMapsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var entity = await _roadMapService.Get(x => x.Id == id);

            if (entity is null)
                return NoContent();

            return Ok(entity);
        }

        // POST api/<RoadMapsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoadMap roadMap)
        {
            await _roadMapService.Insert(roadMap);

            return Created(nameof(Post), roadMap);
        }

        // PUT api/<RoadMapsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoadMap roadMap)
        {
            if (id == default)
                return NotFound();

            if (id != roadMap.Id)
                return BadRequest("Requested Id Mismatch");

            var exists = await _roadMapService.Any(r => r.Id == id);

            if (!exists)
                return NotFound();

            await _roadMapService.Update(roadMap);

            return Ok(roadMap);
        }

        // DELETE api/<RoadMapsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == default)
                return NotFound();

            var entity = await _roadMapService.Get(x => x.Id == id);

            if (entity is null)
                return NotFound();

            await _roadMapService.Delete(entity);

            return Ok();
        }
    }
}
