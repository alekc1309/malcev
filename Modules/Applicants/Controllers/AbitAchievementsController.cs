using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbitAchievementsController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public AbitAchievementsController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> Get(
            [FromQuery] string db,
            [FromBody] DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _context = _factory.Create(db);

            var query = _context.AbitAchievements
                .AsNoTracking()
                .Select(u => new AbitAchievementDto
                {
                    Id = u.Id,
                    Code = u.Code,
                    Name = u.Name,
                    MaxBall = u.MaxBall,
                    Counted = u.Counted,
                    Status = u.Status,
                    BallChanged = u.BallChanged,
                    IdCode = u.IdCode,
                    VerifierCode = u.VerifierCode,
                    ChangeDate = u.ChangeDate,
                    Year = u.Year,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}
