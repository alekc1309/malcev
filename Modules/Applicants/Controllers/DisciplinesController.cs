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
    public class DisciplinesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public DisciplinesController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromQuery] string db, DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("db is required");

            using var ctx = _factory.Create(db);

            var query = ctx.Disciplines
                .AsNoTracking()
                .Select(u => new DisciplineDto
                {
                    Code = u.Code,
                    Name = u.Name,
                });

            return Ok(await DataSourceLoader.LoadAsync(query, loadOptions));
        }
    }
}
