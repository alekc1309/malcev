using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Data;

namespace Project.Api.Modules.Applicants.Extensions
{
    public static class ApplicantsModuleExtensions
    {
        public static IServiceCollection AddApplicantsModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Регистрируем фабрику
            services.AddScoped<ApplicantsDbContextFactory>(sp =>
            {
                return new ApplicantsDbContextFactory(configuration);
            });

            return services;
        }
    }

    public class ApplicantsDbContextFactory
    {
        private readonly IConfiguration _config;

        public ApplicantsDbContextFactory(IConfiguration config)
        {
            _config = config;
        }

        public ApplicantsDbContext Create(string databaseName)
        {
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASS");

            var conn = $"Server={host},{port};Database={databaseName};User Id={user};Password={pass};Encrypt=False;TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<ApplicantsDbContext>()
                .UseSqlServer(conn)
                .Options;

            return new ApplicantsDbContext(options);
        }
    }
}
