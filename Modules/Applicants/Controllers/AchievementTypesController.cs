using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/achievement-types")]
    public class AchievementTypesController : ControllerBase
    {
        private readonly ApplicantsDbContext _db;
        public AchievementTypesController(ApplicantsDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _db.AchievementTypes.ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _db.AchievementTypes.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
