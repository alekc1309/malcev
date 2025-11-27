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
    public class ExamInfoController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public ExamInfoController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/ExamInfo
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.ExamInfos
                .AsNoTracking()
                .Select(e => new AbitExamInfoDto
                {
                    Id = e.Id,
                    ApplicationCode = e.ApplicationCode,
                    BallTotal = e.BallTotal,
                    InCompetition = e.InCompetition,
                    Score1 = e.Score1,
                    Score2 = e.Score2,
                    Score3 = e.Score3,
                    Score4 = e.Score4,
                    Score5 = e.Score5,
                    Score6 = e.Score6,
                    Total = e.Total,
                    AdditionalScoreId = e.AdditionalScoreId,
                    ScoreSum = e.ScoreSum,
                    Exam1 = e.Exam1,
                    Exam2 = e.Exam2,
                    Exam3 = e.Exam3,
                    Exam4 = e.Exam4,
                    Exam5 = e.Exam5,
                    Exam6 = e.Exam6,
                    Disc1 = e.Disc1,
                    Disc2 = e.Disc2,
                    Disc3 = e.Disc3,
                    Disc4 = e.Disc4,
                    Disc5 = e.Disc5,
                    Disc6 = e.Disc6,
                    DiscCode1 = e.DiscCode1,
                    DiscCode2 = e.DiscCode2,
                    DiscCode3 = e.DiscCode3,
                    DiscCode4 = e.DiscCode4,
                    DiscCode5 = e.DiscCode5,
                    DiscCode6 = e.DiscCode6,
                    Mat = e.Mat,
                    Ikt = e.Ikt,
                    Fiz = e.Fiz,
                    Rus = e.Rus,
                    Him = e.Him,
                    Ist = e.Ist,
                    Obsh = e.Obsh,
                    Ris = e.Ris,
                    Lit = e.Lit,
                    Komp = e.Komp,
                    InYaz = e.InYaz,
                    Geo = e.Geo,
                    Bio = e.Bio,
                    TI = e.TI,
                    RusExam = e.RusExam,
                    MatExam = e.MatExam,
                    ObshExam = e.ObshExam,
                    FizExam = e.FizExam,
                    HimExam = e.HimExam,
                    BioExam = e.BioExam,
                    GeoExam = e.GeoExam,
                    IstExam = e.IstExam,
                    IktExam = e.IktExam,
                    AvgTotal = e.AvgTotal,
                    AvgEge = e.AvgEge,
                    AvgVi = e.AvgVi,
                    MinEgeScore = e.MinEgeScore,
                    Date1 = e.Date1,
                    Date2 = e.Date2,
                    Date3 = e.Date3,
                    Date4 = e.Date4,
                    Date5 = e.Date5,
                    Date6 = e.Date6,
                    AdditionalScoreNoEssay = e.AdditionalScoreNoEssay,
                    EssayScore = e.EssayScore,
                    IdWeight = e.IdWeight,
                    SpecialtyCode = e.SpecialtyCode,
                    Z = e.Z,
                    U = e.U,
                    Agreement = e.Agreement,
                    Ege = e.Ege,
                    NoEge = e.NoEge,
                    MinScore = e.MinScore,
                    Admission = e.Admission,
                    Admission1 = e.Admission1,
                    Admission2 = e.Admission2,
                    Admission3 = e.Admission3,
                    Admission4 = e.Admission4,
                    Admission5 = e.Admission5,
                    Admission6 = e.Admission6,
                    Olim100 = e.Olim100
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}