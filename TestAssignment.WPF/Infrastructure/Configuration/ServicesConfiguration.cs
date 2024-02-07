using Microsoft.Extensions.DependencyInjection;
using TestAssignment.BLL.Services;
using TestAssignment.BLL.Services.Interfaces;
using TestAssignment.WPF.Infrastructure.Services;
using TestAssignment.WPF.Infrastructure.Services.Interfaces;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class ServicesConfiguration
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<INavigationService, NavigationService>();
        } 
    }
}
