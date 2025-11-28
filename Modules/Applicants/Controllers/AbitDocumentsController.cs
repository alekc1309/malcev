<<<<<<< HEAD
﻿// Controller
using DevExtreme.AspNet.Data;
=======
﻿using DevExtreme.AspNet.Data;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;
<<<<<<< HEAD
using Project.Api.Modules.Applicants.Models;
=======
using Project.Api.Modules.Applicants.Extensions;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
using Project.Api.Modules.Applicants.Models.Dto;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbitDocumentsController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ApplicantsDbContext _context;

        public AbitDocumentsController(ApplicantsDbContext context)
        {
            _context = context;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // GET: api/AbitDocuments
        [HttpPost]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
=======
        private readonly ApplicantsDbContextFactory _factory;

        public AbitDocumentsController(ApplicantsDbContextFactory factory)
        {
            _factory = factory;
        }

        // ========= READ (DevExtreme DataGrid) =========
        // POST: api/AbitDocuments?db=ИмяБД
        [HttpPost]
        public async Task<IActionResult> Get(
            [FromQuery] string db,
            DataSourceLoadOptions loadOptions)
        {
            if (string.IsNullOrWhiteSpace(db))
                return BadRequest("Parameter 'db' is required");

            using var _context = _factory.Create(db);

>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
            var query = _context.AbitDocuments
                .AsNoTracking()
                .Select(d => new AbitDocumentDto
                {
                    Id = d.Id,
                    DocumentCode = d.DocumentCode,
                    Discipline = d.Discipline,
                    Score = d.Score,
                    Status = d.Status
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
