using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
<<<<<<< HEAD
using Project.Api.Modules.Applicants.Models;
=======
using Project.Api.Modules.Applicants.Extensions;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbitMarksController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _context;

        public AbitMarksController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AbitMarks
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
=======
        private readonly ApplicantsDbContextFactory _factory;

        public AbitMarksController(ApplicantsDbContextFactory factory)
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

>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
            var query = _context.AbitMarks
                .AsNoTracking()
                .Select(u => new AbitMarkDto
                {
                    Id = u.Id,
                    ExamCode = u.ExamCode,
                    Score = u.Score,
<<<<<<< HEAD
                    ExamDate = u.ExamDate,
=======
                    ExamDate = u.ExamDate
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
