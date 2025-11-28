using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Models;
using System.Globalization;
using Microsoft.Extensions.Logging;
=======
using Microsoft.Extensions.Logging;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/applicants/chart")]
    public class ApplicantsChartController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _db;
        private readonly ILogger<ApplicantsChartController> _logger;

        public ApplicantsChartController(ApplicantsDbContext db, ILogger<ApplicantsChartController> logger)
        {
            _db = db;
=======
        private readonly ApplicantsDbContextFactory _factory;
        private readonly ILogger<ApplicantsChartController> _logger;

        public ApplicantsChartController(
            ApplicantsDbContextFactory factory,
            ILogger<ApplicantsChartController> logger)
        {
            _factory = factory;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
            _logger = logger;
        }

        // ------------ DTO запроса ---------------
        public class ChartRequest
        {
            public int TypeCnn { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<int> Years { get; set; } = new();
<<<<<<< HEAD
            public List<string>? Filials { get; set; }
=======
            public List<string>? PK { get; set; }
            public List<string>? Levels { get; set; }
            public List<string>? States { get; set; }
        }

        public class PKRequest
        {
            public List<int> Years { get; set; } = new();
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
            public List<string>? Levels { get; set; }
            public List<string>? States { get; set; }
        }

        // ------------ DTO ответа -----------------
        public class ChartSeriesPoint
        {
            public string Argument { get; set; } = "";
            public int Value { get; set; }
        }

        public class ChartSeriesByYear
        {
            public int Year { get; set; }
            public List<ChartSeriesPoint> Series { get; set; } = new();
        }

<<<<<<< HEAD
        // ------------ API -------------------------
        [HttpPost("build")]
        public async Task<IActionResult> Build([FromBody] ChartRequest req)
        {
            _logger.LogInformation($"TypeCnn: {req.TypeCnn}");
            _logger.LogInformation($"StartDate: {req.StartDate}");
            _logger.LogInformation($"EndDate: {req.EndDate}");
            _logger.LogInformation($"Years: [{string.Join(", ", req.Years)}]");
            _logger.LogInformation($"Filials: [{(req.Filials != null ? string.Join(", ", req.Filials) : "null")}]");
            _logger.LogInformation($"Levels: [{(req.Levels != null ? string.Join(", ", req.Levels) : "null")}]");
            _logger.LogInformation($"States: [{(req.States != null ? string.Join(", ", req.States) : "null")}]");

            var jsonReq = System.Text.Json.JsonSerializer.Serialize(req);
            _logger.LogInformation($"Full request: {jsonReq}");
=======
        public class PKResponse
        {
            public List<string> PKs { get; set; } = new();
        }

        // ------------ API -------------------------
        [HttpPost("helpers/PKs")]
        public async Task<IActionResult> GetPKs(
            [FromQuery] string db,
            [FromBody] PKRequest req)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _db = _factory.Create(db);

            _logger.LogInformation($"GET PKS REQUEST = {System.Text.Json.JsonSerializer.Serialize(req)}");

            IQueryable<AbitSpisokAbit.ApplicantList> q = _db.Applicants;

            if (req.Years?.Any() == true)
                q = q.Where(a => req.Years.Contains(a.RecruitmentYear ?? -1));
            else
                q = q.Where(a => a.RecruitmentYear.HasValue);

            if (req.Levels?.Any() == true)
                q = q.Where(a => req.Levels.Contains(a.LevelName));

            if (req.States?.Any() == true)
                q = q.Where(a => req.States.Contains(a.ApplicationStatus));

            var pks = await q
                .Where(a => !string.IsNullOrEmpty(a.PK))
                .Select(a => a.PK!)
                .Distinct()
                .ToListAsync();

            var response = new PKResponse
            {
                PKs = pks.Distinct().ToList()
            };

            return Ok(response);
        }

        [HttpPost("build")]
        public async Task<IActionResult> Build(
            [FromQuery] string db,
            [FromBody] ChartRequest req)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _db = _factory.Create(db);

            _logger.LogInformation($"CHART REQUEST = {System.Text.Json.JsonSerializer.Serialize(req)}");
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

            var result = new List<ChartSeriesByYear>();

            foreach (var year in req.Years)
            {
<<<<<<< HEAD
                // диапазон дат как в VB-функции GetRange(year)
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                var start = new DateTime(year, req.StartDate.Month, req.StartDate.Day);
                var end = new DateTime(year, req.EndDate.Month, req.EndDate.Day);

                var daysRange = Enumerable.Range(0, (end - start).Days + 1)
                    .Select(x => start.AddDays(x))
                    .ToList();

<<<<<<< HEAD
                // выборка дат из БД — точная копия VB GetQ()
                var dates = await GetDates(req, year);
=======
                var dates = await GetDates(_db, req, year);
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

                int cumulative = 0;
                var series = new List<ChartSeriesPoint>();

                foreach (var day in daysRange)
                {
                    int count = dates.Count(d => d.Date == day.Date);
                    cumulative += count;

                    series.Add(new ChartSeriesPoint
                    {
<<<<<<< HEAD
                        Argument = GetDateStr(day),  // "1.Июнь", "2.Июль" и т.д. как в VB
=======
                        Argument = GetDateStr(day),
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                        Value = cumulative
                    });
                }

                result.Add(new ChartSeriesByYear
                {
                    Year = year,
                    Series = series
                });
            }

            return Ok(result);
        }

        // =============================================================
<<<<<<< HEAD
        // ========= ПОЛНЫЙ АНАЛОГ GetQ() в LINQ =======================
        // =============================================================
        private async Task<List<DateTime>> GetDates(ChartRequest req, int year)
        {
            IQueryable<AbitSpisokAbit.ApplicantList> q = _db.Applicants;

            // Годы
            q = q.Where(a => req.Years.Contains(a.RecruitmentYear ?? -1));

            _logger.LogInformation($"GetDates - Years filter applied: [{string.Join(", ", req.Years)}]");

            // Филиалы - используем Filials поле из модели
            if (req.Filials != null && req.Filials.Any())
            {
                q = q.Where(a => req.Filials.Contains(a.Filials));
                _logger.LogInformation($"GetDates - Filials filter applied: [{string.Join(", ", req.Filials)}]");
            }

            // Уровень образования
            if (req.Levels != null && req.Levels.Any())
            {
                q = q.Where(a => req.Levels.Contains(a.LevelName));
                _logger.LogInformation($"GetDates - Levels filter applied: [{string.Join(", ", req.Levels)}]");
            }

            // Статус заявления
            if (req.States != null && req.States.Any())
            {
                q = q.Where(a => req.States.Contains(a.ApplicationStatus));
                _logger.LogInformation($"GetDates - States filter applied: [{string.Join(", ", req.States)}]");
            }
=======
        private async Task<List<DateTime>> GetDates(
            ApplicantsDbContext _db,
            ChartRequest req, int year)
        {
            IQueryable<AbitSpisokAbit.ApplicantList> q = _db.Applicants;

            q = q.Where(a => req.Years.Contains(a.RecruitmentYear ?? -1));

            if (req.PK?.Any() == true)
                q = q.Where(a => req.PK.Contains(a.PK));

            if (req.Levels?.Any() == true)
                q = q.Where(a => req.Levels.Contains(a.LevelName));

            if (req.States?.Any() == true)
                q = q.Where(a => req.States.Contains(a.ApplicationStatus));
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd

            switch (req.TypeCnn)
            {
                case 1:
<<<<<<< HEAD
                    _logger.LogInformation("GetDates - Executing case 1 query");
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                    return await q
                        .Where(a => new[] { 1, 2, 4, 5, 7, 8 }.Contains(a.EducationService ?? -1))
                        .Where(a => a.DocsSubmitDate != null)
                        .Select(a => a.DocsSubmitDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 2:
<<<<<<< HEAD
                    _logger.LogInformation("GetDates - Executing case 2 query");
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                    return await q
                        .Where(a => a.DocsSubmitDate != null)
                        .GroupBy(a => a.Id)
                        .Select(g => g.Max(a => a.DocsSubmitDate!.Value.Date))
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 3:
<<<<<<< HEAD
                    _logger.LogInformation("GetDates - Executing case 3 query");
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                    return await q
                        .Where(a => a.EnrollmentDate != null)
                        .Select(a => a.EnrollmentDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 4:
<<<<<<< HEAD
                    _logger.LogInformation("GetDates - Executing case 4 query");
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
                    return await q
                        .Where(a => a.RefusedEnrollmentDate != null)
                        .Select(a => a.RefusedEnrollmentDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();
<<<<<<< HEAD

                default:
                    _logger.LogInformation("GetDates - Executing default query");
                    return await q
                        .Where(a => a.DocsSubmitDate != null)
                        .Select(a => a.DocsSubmitDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();
            }
        }

        // =============================================================
        // ============== АНАЛОГ GetDateStr из VB ======================
        // =============================================================
        private string GetDateStr(DateTime val)
        {
            return val.Day + "." + GetNameMonth(val.Month);
        }

        private string GetNameMonth(int m)
        {
            switch (m)
            {
                case 1: return "Янв.";
                case 2: return "Фев.";
                case 3: return "Март";
                case 4: return "Апр.";
                case 5: return "Май";
                case 6: return "Июнь";
                case 7: return "Июль";
                case 8: return "Авг.";
                case 9: return "Сент.";
                case 10: return "Окт.";
                case 11: return "Нояб.";
                case 12: return "Дек.";
                default: return "Янв.";
            }
        }
=======
            }

            return await q
                .Where(a => a.DocsSubmitDate != null)
                .Select(a => a.DocsSubmitDate!.Value.Date)
                .Where(d => d.Year == year)
                .ToListAsync();
        }

        private string GetDateStr(DateTime val)
            => val.Day + "." + GetNameMonth(val.Month);

        private string GetNameMonth(int m) =>
            m switch
            {
                1 => "Янв.",
                2 => "Фев.",
                3 => "Март",
                4 => "Апр.",
                5 => "Май",
                6 => "Июнь",
                7 => "Июль",
                8 => "Авг.",
                9 => "Сент.",
                10 => "Окт.",
                11 => "Нояб.",
                12 => "Дек.",
                _ => "Янв."
            };
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
    }
}