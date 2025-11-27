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
    public class PaymentEntriesController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public PaymentEntriesController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/PaymentEntries
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
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