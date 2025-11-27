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
    public class ExamTypesController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public ExamTypesController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/ExamTypes
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.ExamTypes
                .AsNoTracking()
                .Select(u => new ExamTypeDto
                {
                    Code = u.Code,
                    Name = u.Name,
                    Comment = u.Comment,
                    ShortName = u.ShortName,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}