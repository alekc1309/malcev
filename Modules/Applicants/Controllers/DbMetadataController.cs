using DotNetEnv;
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
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var connStr = _config.GetConnectionString("sqlServer");

            var databases = new List<string>();

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
                    databases.Add(reader.GetString(0));
                }
            }

            var result = new
            {
                Databases = databases,
                IP = host
            };

            return Ok(result);
        }
    }
}