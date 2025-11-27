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
    public class AbitAchievementsController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AbitAchievementsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AbitAchievements
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] DataSourceLoadOptions loadOptions)
        {
            var query = _context.AbitAchievements
                .AsNoTracking()
                .Select(u => new AbitAchievementDto
                {
                    Id = u.Id,
                    Code = u.Code,
                    Name = u.Name,
                    MaxBall = u.MaxBall,
                    Counted = u.Counted,
                    Status = u.Status,
                    BallChanged = u.BallChanged,
                    IdCode = u.IdCode,
                    VerifierCode = u.VerifierCode,
                    ChangeDate = u.ChangeDate,
                    Year = u.Year,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }

        // ========= GET File Info by Achievement Code =========
        //// GET: api/AbitAchievements/{code}/file-info
        //[HttpGet("{code}/file-info")]
        //public async Task<IActionResult> GetFileInfoByAchievementCode(int code)
        //{
        //    var file = await _context.Files
        //        .AsNoTracking()
        //        .Where(f => f.AchievementId == code && f.IsDeleted != true)
        //        .Select(f => new { f.FileId, f.FileGuid })
        //        .FirstOrDefaultAsync();

        //    if (file == null)
        //    {
        //        return NotFound(new { message = $"File not found for achievement code: {code}" });
        //    }

        //    return Ok(new { FileId = file.FileId, FileGuid = file.FileGuid });
        //}
    }
}