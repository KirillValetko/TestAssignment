using Microsoft.Extensions.DependencyInjection;
using TestAssignment.DAL.Repositories;
using TestAssignment.DAL.Repositories.Interfaces;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFileRepository, FileRepository>();
        }
    }
}
