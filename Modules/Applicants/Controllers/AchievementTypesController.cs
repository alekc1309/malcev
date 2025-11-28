using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
<<<<<<< HEAD
=======
using Project.Api.Modules.Applicants.Extensions;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/achievement-types")]
    public class AchievementTypesController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _db;
        public AchievementTypesController(ApplicantsDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _db.AchievementTypes.ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
=======
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

>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
            var item = await _db.AchievementTypes.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
