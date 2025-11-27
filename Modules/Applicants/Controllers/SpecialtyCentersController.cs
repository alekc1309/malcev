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
    public class SpecialtyCentersController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public SpecialtyCentersController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/SpecialtyCenters
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.SpecialtyCenters
                .AsNoTracking()
                .Select(s => new SpecialtyCenterDto
                {
                    Id = s.Id,
                    SpecialtyCode = s.SpecialtyCode,
                    OrgCode = s.OrgCode,
                    ProposalNumber = s.ProposalNumber,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}