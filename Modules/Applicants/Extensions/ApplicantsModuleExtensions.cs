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
            services.AddDbContext<ApplicantsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("abit")));

            return services;
        }
    }
}
