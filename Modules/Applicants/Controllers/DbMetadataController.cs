using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Project.Api.Modules.Applicants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbMetadataController : ControllerBase
    {
        private readonly IConfiguration _config;

        public DbMetadataController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("databases")]
        public async Task<IActionResult> GetDatabases()
        {
            var connStr = _config.GetConnectionString("sqlServer");

            var result = new List<string>();

            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();

                var cmd = new SqlCommand(
                    @"SELECT name FROM sys.databases 
                      WHERE name NOT IN ('master','tempdb','model','msdb')
                      ORDER BY name", conn);

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Add(reader.GetString(0));
                }
            }

            return Ok(result);
        }
    }
}
