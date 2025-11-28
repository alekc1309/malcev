using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
<<<<<<< HEAD
=======
using Project.Api.Modules.Applicants.Extensions;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
using Project.Api.Modules.Applicants.Models;
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantsController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _context;

        public ApplicantsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.Applicants
                .AsNoTracking()
                .Join(
                    _context.ExamInfos,
                    applicant => applicant.ApplicationCode,
                    examInfo => examInfo.ApplicationCode,
                    (applicant, examInfo) => new { applicant, examInfo }
                )
=======
        private readonly ApplicantsDbContextFactory _factory;

        public ApplicantsController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] string db, [FromRoute] int id)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("db is required");

            using var _context = _factory.Create(db);

            var applicantData = await _context.Applicants
                .AsNoTracking()
                .Join(_context.ExamInfos,
                    a => a.ApplicationCode,
                    e => e.ApplicationCode,
                    (a, e) => new { applicant = a, examInfo = e })
                .Where(joined => joined.applicant.Id == id)
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                .Select(joined => new AbitSpisokAbitDto
                {
                    // ======= Основные поля =======
                    Id = joined.applicant.Id,
                    ApplicationCode = joined.applicant.ApplicationCode,
                    FullName = joined.applicant.FullName,
                    LastName = joined.applicant.LastName,
                    FirstName = joined.applicant.FirstName,
                    MiddleName = joined.applicant.MiddleName,
                    Email = joined.applicant.Email,
                    Mobile = joined.applicant.Mobile,
                    BirthDate = joined.applicant.BirthDate,
                    Gender = joined.applicant.Gender,
                    SpecialtyCode = joined.applicant.SpecialtyCode,
                    SpecialtyName = joined.applicant.SpecialtyName,
                    SpecialName = joined.applicant.SpecialName,
                    Specialization = joined.applicant.Specialization,
                    Profile = joined.applicant.Profile,
                    Faculty = joined.applicant.Faculty,
                    OKSO = joined.applicant.OKSO,
                    Level = joined.applicant.Level,
                    LevelName = joined.applicant.LevelName,
                    LevelCategory = joined.applicant.LevelCategory,
                    EducationForm = joined.applicant.EducationForm,
                    Address = joined.applicant.Address,
                    Address2 = joined.applicant.Address2,

                    Dormitory = joined.applicant.DormitoryRaw == null || string.IsNullOrWhiteSpace(joined.applicant.DormitoryRaw) ? null :
                        joined.applicant.DormitoryRaw == "1" ||
                        joined.applicant.DormitoryRaw.Equals("да", StringComparison.OrdinalIgnoreCase) ||
                        joined.applicant.DormitoryRaw.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                        joined.applicant.DormitoryRaw.Equals("нуждается", StringComparison.OrdinalIgnoreCase) ? true :
                        joined.applicant.DormitoryRaw == "0" ||
                        joined.applicant.DormitoryRaw.Equals("нет", StringComparison.OrdinalIgnoreCase) ||
                        joined.applicant.DormitoryRaw.Equals("false", StringComparison.OrdinalIgnoreCase) ? false : null,

                    EducationType = joined.applicant.EducationType,
                    School = joined.applicant.School,
                    SchoolLocation = joined.applicant.SchoolLocation,
                    GraduationYear = joined.applicant.GraduationYear,
                    CertificateSeries = joined.applicant.CertificateSeries,
                    CertificateNumber = joined.applicant.CertificateNumber,
                    EducationDocType = joined.applicant.EducationDocType,
                    EducationType2 = joined.applicant.EducationType2,
                    EduDocIssueDate = joined.applicant.EduDocIssueDate,
                    Citizenship = joined.applicant.Citizenship,
                    RegionPP = joined.applicant.RegionPP,
                    DistrictPP = joined.applicant.DistrictPP,
                    CountryPP = joined.applicant.CountryPP,
                    Region = joined.applicant.Region,
                    Original = joined.applicant.Original,
                    OriginalDocument = joined.applicant.OriginalDocument,
                    OriginalSubmissionDate = joined.applicant.OriginalSubmissionDate,
                    BenefitsName = joined.applicant.BenefitsName,
                    Snils = joined.applicant.Snils,
                    PP = joined.applicant.PP,
                    WithoutExam = joined.applicant.WithoutExam,
                    BenefitType = joined.applicant.BenefitType,
                    Priority = joined.applicant.Priority,
                    ServicePriority = joined.applicant.ServicePriority,
                    EPGUCode = joined.applicant.EPGUCode,
                    EPGUApplicationCode = joined.applicant.EPGUApplicationCode,
                    Payment = joined.applicant.Payment,
                    ParentPhone = joined.applicant.ParentPhone,
                    DocsSubmitDate = joined.applicant.DocsSubmitDate,
                    RefusedEnrollment = joined.applicant.RefusedEnrollment,
                    RefusedEnrollmentDate = joined.applicant.RefusedEnrollmentDate,
                    Enrolled = joined.applicant.Enrolled,
                    EnrollmentDate = joined.applicant.EnrollmentDate,
                    Order = joined.applicant.Order,
                    TookDocs = joined.applicant.TookDocs,
                    TookDocsDate = joined.applicant.TookDocsDate,
                    Document = joined.applicant.Document,
                    Ld = joined.applicant.Ld,
                    CaseNumber = joined.applicant.CaseNumber,
                    Gradebook = joined.applicant.Gradebook,
                    Status = joined.applicant.Status,
                    SpecialStatus = joined.applicant.SpecialStatus,
                    ApplicationStatus = joined.applicant.ApplicationStatus,
                    AvgAttestatScore = joined.applicant.AvgAttestatScore,
                    EducationService = joined.applicant.EducationService,
                    OOP = joined.applicant.OOP,
                    CN = joined.applicant.CN,
                    SN = joined.applicant.SN,
                    QV = joined.applicant.QV,
                    MIB = joined.applicant.MIB,
                    Costs = joined.applicant.Costs,
                    Sum = joined.applicant.Sum,
                    AdditionalSet = joined.applicant.AdditionalSet,
                    Conditions = joined.applicant.Conditions,
                    LearningConditions = joined.applicant.LearningConditions,
                    BasisNumber = joined.applicant.BasisNumber,
                    NumberLD = joined.applicant.NumberLD,
                    RecruitmentYear = joined.applicant.RecruitmentYear,
                    BenefitDocCode = joined.applicant.BenefitDocCode,
                    Deleted = joined.applicant.Deleted,
                    OtherVUZ = joined.applicant.OtherVUZ,
<<<<<<< HEAD
=======
                    PK = joined.applicant.PK,
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

                    PlanNabora =
                        joined.applicant.EducationService == 1 ? (joined.applicant.OOP ?? 0).ToString() :
                        joined.applicant.EducationService == 2 ? (joined.applicant.CN ?? 0).ToString() :
                        joined.applicant.EducationService == 3 ? (joined.applicant.SN ?? 0).ToString() :
                        joined.applicant.EducationService == 5 ? (joined.applicant.QV ?? 0).ToString() :
                        joined.applicant.EducationService == 6 ? (joined.applicant.MIB ?? 0).ToString() : "0",

                    OriginalDoc = joined.applicant.OriginalSubmissionDate.HasValue ? "Да" : "Нет",
                    HighestPriority = (joined.applicant.Priority == 1),
                    HighestPriorityText = (joined.applicant.Priority == 1) ? "Первый приоритет" : "Нет",
                    HighestPriorityOriginal =
                        (joined.applicant.Priority == 1 && (joined.applicant.OriginalDocument ?? false)) ? "Да" : "Нет",

                    // ======= Экзамены =======
                    Exam1 = joined.examInfo.Exam1,
                    Exam2 = joined.examInfo.Exam2,
                    Exam3 = joined.examInfo.Exam3,
                    Exam4 = joined.examInfo.Exam4,
                    Exam5 = joined.examInfo.Exam5,
                    Exam6 = joined.examInfo.Exam6,

                    Disc1 = joined.examInfo.Disc1,
                    Disc2 = joined.examInfo.Disc2,
                    Disc3 = joined.examInfo.Disc3,
                    Disc4 = joined.examInfo.Disc4,
                    Disc5 = joined.examInfo.Disc5,
                    Disc6 = joined.examInfo.Disc6,

                    Score1 = joined.examInfo.Score1 ?? 0,
                    Score2 = joined.examInfo.Score2 ?? 0,
                    Score3 = joined.examInfo.Score3 ?? 0,
                    Score4 = joined.examInfo.Score4 ?? 0,
                    Score5 = joined.examInfo.Score5 ?? 0,
                    Score6 = joined.examInfo.Score6 ?? 0,

                    AdditionalScoreId = joined.examInfo.AdditionalScoreId ?? 0,
                    ScoreSum = joined.examInfo.ScoreSum ?? 0,

                    Scores = new[]
                    {
                        joined.examInfo.Score1,
                        joined.examInfo.Score2,
                        joined.examInfo.Score3,
                        joined.examInfo.Score4,
                        joined.examInfo.Score5,
                        joined.examInfo.Score6
                    }.Count(x => x.HasValue),

                    Total = (joined.examInfo.ScoreSum ?? 0).ToString(),

                    Count = new[]
                    {
                        joined.examInfo.Score1,
                        joined.examInfo.Score2,
                        joined.examInfo.Score3,
                        joined.examInfo.Score4,
                        joined.examInfo.Score5,
                        joined.examInfo.Score6
                    }.Count(x => x.HasValue),

                    NoExamType =
                        string.IsNullOrEmpty(joined.examInfo.Exam1) &&
                        string.IsNullOrEmpty(joined.examInfo.Exam2) &&
                        string.IsNullOrEmpty(joined.examInfo.Exam3),

                    Company = joined.applicant.Company,

                    // ============================================================
                    //            >>>   НОВЫЕ СЛОЖНЫЕ ВЫЧИСЛЯЕМЫЕ ПОЛЯ   <<<
                    // ============================================================

                    // ---------- Согласие ----------
                    ConsentedDirection = _context.ApplicantApplications
                        .Where(a =>
                            a.ApplicationCode == joined.applicant.ApplicationCode &&
                            a.ConsentToEnrollment == true &&
                            (a.Deleted == false || a.Deleted == null) &&
                            (a.TookDocs == false || a.TookDocs == null)
                        )
                        .Any()
                            ? joined.applicant.OKSO
                            : null,

<<<<<<< HEAD

=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                    ConsentUploadDate = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == -9)
                        .SelectMany(d => _context.Files
                            .Where(f => f.DocumentId == d.Code && f.IsDeleted != true)
                            .OrderBy(f => f.CreatedOn)
                            .Select(f => f.CreatedOn)
                        )
                        .Select(dt => dt.HasValue
                            ? dt.Value.ToString("dd.MM.yyyy HH:mm:ss")
                            : null)
                        .FirstOrDefault(),

                    ConsentFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == -9)
                        .SelectMany(d => _context.Files
                            .Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count(),

                    // ---------- Зелёная волна ----------
                    GreenWaveDate = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == 39)
                        .SelectMany(d => _context.Files
                            .Where(f => f.DocumentId == d.Code && f.IsDeleted != true)
                            .OrderBy(f => f.CreatedOn)
                            .Select(f => f.CreatedOn))
                        .Select(dt => dt.HasValue
                            ? dt.Value.ToString("dd.MM.yyyy HH:mm:ss")
                            : null)
                        .FirstOrDefault(),

                    GreenWaveFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == 39)
                        .SelectMany(d => _context.Files.Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count(),

                    // ---------- Снижение ----------
                    ReductionDate = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == 43)
                        .SelectMany(d => _context.Files
                            .Where(f => f.DocumentId == d.Code && f.IsDeleted != true)
                            .OrderBy(f => f.CreatedOn)
                            .Select(f => f.CreatedOn))
                        .Select(dt => dt.HasValue
                            ? dt.Value.ToString("dd.MM.yyyy HH:mm:ss")
                            : null)
                        .FirstOrDefault(),

                    ReductionFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == joined.applicant.Id && d.DocumentCode == 43)
                        .SelectMany(d => _context.Files.Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count(),
<<<<<<< HEAD
=======
                })
                .FirstOrDefaultAsync();

            if (applicantData == null)
                return NotFound();

            return Ok(applicantData);
        }

        [HttpPost("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] string db, DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("db is required");

            using var _context = _factory.Create(db);

            var query = _context.Applicants
                .AsNoTracking()
                .Select(applicant => new
                {
                    ApplicationCode = applicant.ApplicationCode,
                    FullName = applicant.FullName,
                    LastName = applicant.LastName,
                    FirstName = applicant.FirstName,
                    MiddleName = applicant.MiddleName,
                    Email = applicant.Email,
                    Mobile = applicant.Mobile,
                    SpecialtyName = applicant.SpecialtyName,
                    Faculty = applicant.Faculty,
                    EducationForm = applicant.EducationForm,
                    Original = applicant.Original,
                    Enrolled = applicant.Enrolled,
                    Status = applicant.Status,
                    ApplicationStatus = applicant.ApplicationStatus,
                    RecruitmentYear = applicant.RecruitmentYear,
                    Priority = applicant.Priority,
                    AvgAttestatScore = applicant.AvgAttestatScore,
                    ScoreSum = _context.ExamInfos
                        .Where(e => e.ApplicationCode == applicant.ApplicationCode)
                        .Select(e => e.ScoreSum)
                        .FirstOrDefault() ?? 0,
                    ConsentFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == applicant.Id && d.DocumentCode == -9)
                        .SelectMany(d => _context.Files
                            .Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count(),
                    GreenWaveFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == applicant.Id && d.DocumentCode == 39)
                        .SelectMany(d => _context.Files.Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count(),
                    ReductionFilesCount = _context.AllDocuments
                        .Where(d => d.AbitId == applicant.Id && d.DocumentCode == 43)
                        .SelectMany(d => _context.Files.Where(f => f.DocumentId == d.Code && f.IsDeleted != true))
                        .Count()
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
