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
    public class ExamTypesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public ExamTypesController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromQuery] string db, DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("db is required");

            using var ctx = _factory.Create(db);

            var query = ctx.ExamTypes
                .AsNoTracking()
                .Select(u => new ExamTypeDto
                {
                    Code = u.Code,
                    Name = u.Name,
                    Comment = u.Comment,
                    ShortName = u.ShortName,
                });

            return Ok(await DataSourceLoader.LoadAsync(query, loadOptions));
        }
    }
}
