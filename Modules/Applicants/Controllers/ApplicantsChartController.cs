using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/applicants/chart")]
    public class ApplicantsChartController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;
        private readonly ILogger<ApplicantsChartController> _logger;

        public ApplicantsChartController(
            ApplicantsDbContextFactory factory,
            ILogger<ApplicantsChartController> logger)
        {
            _factory = factory;
            _logger = logger;
        }

        // ------------ DTO запроса ---------------
        public class ChartRequest
        {
            public int TypeCnn { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<int> Years { get; set; } = new();
            public List<string>? PK { get; set; }
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

        // ------------ API -------------------------
        [HttpPost("build")]
        public async Task<IActionResult> Build(
            [FromQuery] string db,
            [FromBody] ChartRequest req)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _db = _factory.Create(db);

            _logger.LogInformation($"REQUEST = {System.Text.Json.JsonSerializer.Serialize(req)}");

            var result = new List<ChartSeriesByYear>();

            foreach (var year in req.Years)
            {
                var start = new DateTime(year, req.StartDate.Month, req.StartDate.Day);
                var end = new DateTime(year, req.EndDate.Month, req.EndDate.Day);

                var daysRange = Enumerable.Range(0, (end - start).Days + 1)
                    .Select(x => start.AddDays(x))
                    .ToList();

                var dates = await GetDates(_db, req, year);

                int cumulative = 0;
                var series = new List<ChartSeriesPoint>();

                foreach (var day in daysRange)
                {
                    int count = dates.Count(d => d.Date == day.Date);
                    cumulative += count;

                    series.Add(new ChartSeriesPoint
                    {
                        Argument = GetDateStr(day),
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

            switch (req.TypeCnn)
            {
                case 1:
                    return await q
                        .Where(a => new[] { 1, 2, 4, 5, 7, 8 }.Contains(a.EducationService ?? -1))
                        .Where(a => a.DocsSubmitDate != null)
                        .Select(a => a.DocsSubmitDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 2:
                    return await q
                        .Where(a => a.DocsSubmitDate != null)
                        .GroupBy(a => a.Id)
                        .Select(g => g.Max(a => a.DocsSubmitDate!.Value.Date))
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 3:
                    return await q
                        .Where(a => a.EnrollmentDate != null)
                        .Select(a => a.EnrollmentDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();

                case 4:
                    return await q
                        .Where(a => a.RefusedEnrollmentDate != null)
                        .Select(a => a.RefusedEnrollmentDate!.Value.Date)
                        .Where(d => d.Year == year)
                        .ToListAsync();
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
    }
}