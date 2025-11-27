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
    public class DocumentShortsController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public DocumentShortsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/DocumentShorts
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.DocumentsShort
                .AsNoTracking()
                .Select(u => new DocumentShortDto
                {
                    Id = u.Id,
                    DocumentCode = u.DocumentCode,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}