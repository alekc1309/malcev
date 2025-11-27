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
    public class SpecialtyCentersController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public SpecialtyCentersController(ApplicantsDbContextFactory factory)
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

            var query = _context.SpecialtyCenters
                .AsNoTracking()
                .Select(s => new SpecialtyCenterDto
                {
                    Id = s.Id,
                    SpecialtyCode = s.SpecialtyCode,
                    OrgCode = s.OrgCode,
                    ProposalNumber = s.ProposalNumber,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
            return Ok(result);
        }
    }
}
