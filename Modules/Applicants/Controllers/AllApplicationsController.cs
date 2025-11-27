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
    public class AllApplicationsController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AllApplicationsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // POST: api/AllApplications
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.AllApplications
                .AsNoTracking()
                .Select(a => new AllApplicationDto
                {
                    ApplicationCode = a.ApplicationCode,
                    Costs = a.Costs,
                    Sum = a.Sum,
                    ContractNumber = a.ContractNumber,
                    PeriodFrom = a.PeriodFrom,
                    PeriodTo = a.PeriodTo,
                    PaymentPeriod = a.PaymentPeriod,
                    ReceiptNumber = a.ReceiptNumber,
                    PayDate = a.PayDate,
                    PayerType = a.PayerType,
                    ContractDate = a.ContractDate,
                    PaymentCode = a.PaymentCode,
                    Consented = a.Consented,
                    ConsentDate = a.ConsentDate,
                    OperatorCode = a.OperatorCode,

                    // Новые поля
                    ConsentedDirection = a.ConsentedDirection,
                    ConsentUploadDate = a.ConsentUploadDate,
                    ConsentFilesCount = a.ConsentFilesCount,
                    GreenWaveDate = a.GreenWaveDate,
                    GreenWaveFilesCount = a.GreenWaveFilesCount,
                    ReductionDate = a.ReductionDate,
                    ReductionFilesCount = a.ReductionFilesCount
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);
            return Ok(result);
        }
    }
}
