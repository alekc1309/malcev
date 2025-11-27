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
    public class AchievementTypeGroupsController : ControllerBase
    {
        private readonly ApplicantsDbContext _context;

        public AchievementTypeGroupsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AchievementTypeGroups
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var query = _context.AchievementTypeGroups
                .AsNoTracking()
                .Select(u => new AchievementTypeGroupDto
                {
                    Id = u.Id,
                    TypeCode = u.TypeCode,
                    GroupCode = u.GroupCode,
                });

            var result = await DataSourceLoader.LoadAsync(query, loadOptions);

            return Ok(result);
        }
    }
}