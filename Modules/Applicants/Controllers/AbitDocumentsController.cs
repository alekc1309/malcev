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
    public class AbitDocumentsController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public AbitDocumentsController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // POST: api/AbitDocuments?db=ИмяБД
        [HttpPost]
        public async Task<IActionResult> Get(
            [FromQuery] string db,
            DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _context = _factory.Create(db);

            var query = _context.AbitDocuments
                .AsNoTracking()
                .Select(d => new AbitDocumentDto
                {
                    Id = d.Id,
                    DocumentCode = d.DocumentCode,
                    Discipline = d.Discipline,
                    Score = d.Score,
                    Status = d.Status
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}
