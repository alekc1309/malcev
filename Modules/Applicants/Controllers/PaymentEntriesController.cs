using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
using Project.Api.Modules.Applicants.Extensions;
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentEntriesController : ControllerBase
    {
        private readonly ApplicantsDbContextFactory _factory;

        public PaymentEntriesController(ApplicantsDbContextFactory factory)
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

            var query = _context.Payments
                .AsNoTracking()
                .Select(p => new PaymentEntryDto
                {
                    Code = p.Code,
                    PaymentName = p.PaymentName,
                    IsDate = p.IsDate,
                    Period = p.Period,
                    FormCode = p.FormCode,
                    IsDeleted = p.IsDeleted
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
            return Ok(result);
        }
    }
}
