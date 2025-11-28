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
    public class ExamTypesController : ControllerBase
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                .AsNoTracking()
                .Select(u => new ExamTypeDto
                {
                    Code = u.Code,
                    Name = u.Name,
                    Comment = u.Comment,
                    ShortName = u.ShortName,
                });

<<<<<<< HEAD
            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}
=======
            return Ok(await DataSourceLoader.LoadAsync(query, loadOptions));
        }
    }
}
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
