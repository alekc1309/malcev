using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbitSpisokAbitController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public AbitSpisokAbitController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> Get(
            [FromQuery] string db,
            DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _context = _factory.Create(db);

            var query = _context.Applicants
                .AsNoTracking()
                .Select(a => new
                {
                    a.Id,
                    a.ApplicationCode,
                    a.FullName,
                    a.LastName,
                    a.FirstName,
                    a.MiddleName,
                    a.Email,
                    a.Mobile,
                    a.LevelName,
                    a.Filials,
                    a.ApplicationStatus,
                    a.RecruitmentYear
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}
