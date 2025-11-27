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
    public class AbitExamComputedController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AbitExamComputedController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AbitExamComputed
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.ExamInfos
                .AsNoTracking()
                .Select(u => new AbitExamComputedDto
                {
                    ApplicationCode = u.ApplicationCode,
                    Score1 = u.Score1 ?? 0,
                    Score2 = u.Score2 ?? 0,
                    Score3 = u.Score3 ?? 0,
                    Score4 = u.Score4 ?? 0,
                    Score5 = u.Score5 ?? 0,
                    Score6 = u.Score6 ?? 0,
                    AdditionalScoreId = u.AdditionalScoreId ?? 0,
                    ScoreSum = u.ScoreSum ?? 0,
                    Total = u.Total ?? 0,
                    Count = new[] { u.Score1, u.Score2, u.Score3, u.Score4, u.Score5, u.Score6 }
                        .Count(x => x.HasValue),
                    NoExamType = string.IsNullOrEmpty(u.Exam1) &&
                                string.IsNullOrEmpty(u.Exam2) &&
                                string.IsNullOrEmpty(u.Exam3),
                    Exam1 = u.Exam1,
                    Exam2 = u.Exam2,
                    Exam3 = u.Exam3,
                    Exam4 = u.Exam4,
                    Exam5 = u.Exam5,
                    Exam6 = u.Exam6,
                    Disc1 = u.Disc1,
                    Disc2 = u.Disc2,
                    Disc3 = u.Disc3,
                    Disc4 = u.Disc4,
                    Disc5 = u.Disc5,
                    Disc6 = u.Disc6,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}