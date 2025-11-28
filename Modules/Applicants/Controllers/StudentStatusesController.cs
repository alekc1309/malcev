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
    public class StudentStatusesController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _context;

        public StudentStatusesController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/StudentStatuses
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.StudentStatuses
=======
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
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                .Select(s => new StudentStatusDto
                {
                    Code = s.Code,
                    Status = s.Status,
                    Description = s.Description,
                    ShortName = s.ShortName
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
<<<<<<< HEAD

            return Ok(result);
        }

        // ========= GET BY ID =========


   
    }
}
=======
            return Ok(result);
        }
    }
}
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
