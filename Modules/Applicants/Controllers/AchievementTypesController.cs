using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/achievement-types")]
    public class AchievementTypesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public AchievementTypesController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string db)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _db = _factory.Create(db);

            return Ok(await _db.AchievementTypes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] string db)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _db = _factory.Create(db);

            var item = await _db.AchievementTypes.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
