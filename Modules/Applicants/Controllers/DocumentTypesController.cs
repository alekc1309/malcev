using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models;
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public DocumentTypesController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        // GET: api/DocumentTypes?db=АбитуриентыДГТУ_2024
        [HttpPost]
        public async Task<IActionResult> Get(
            [FromQuery] string db,
            DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _context = _factory.Create(db);

            var query = _context.DocumentTypes
                .AsNoTracking()
                .Select(d => new DocumentTypeDto
                {
                    Code = d.Code,
                    Name = d.Name,
                    Comment = d.Comment,
                    ShortName = d.ShortName,
                    IsDocument = d.IsDocument
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
            return Ok(result);
        }
    }
}
