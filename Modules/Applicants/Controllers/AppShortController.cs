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
    public class AppShortController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AppShortController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AppShort
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.ApplicationsShort
                .AsNoTracking()
                .Select(u => new ApplicationShortDto
                {
                    ApplicationCode = u.ApplicationCode,
                    ContractNumber = u.ContractNumber,
                    PaymentCode = u.PaymentCode,
                    PayerType = u.PayerType,
                    ContractDate = u.ContractDate,
                    Costs = u.Costs,
                    Amount = u.Amount,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}