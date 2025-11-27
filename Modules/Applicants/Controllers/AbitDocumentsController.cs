// Controller
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Models;
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbitDocumentsController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AbitDocumentsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AbitDocuments
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
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