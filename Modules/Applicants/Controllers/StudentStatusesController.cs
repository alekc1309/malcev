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
    public class StudentStatusesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public StudentStatusesController(ApplicantsDbContextFactory factory)
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

            var query = _context.StudentStatuses
                .AsNoTracking()
                .Select(s => new StudentStatusDto
                {
                    Code = s.Code,
                    Status = s.Status,
                    Description = s.Description,
                    ShortName = s.ShortName
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
            return Ok(result);
        }
    }
}
