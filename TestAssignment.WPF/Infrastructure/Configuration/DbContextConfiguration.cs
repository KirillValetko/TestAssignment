using Microsoft.Extensions.DependencyInjection;
using TestAssignment.DAL.Infrastructure;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class DbContextConfiguration
    {
        public static void InitDbContext(this IServiceCollection services)
        {
            services.AddSingleton<FileDbContext>();
        }
    }
}
