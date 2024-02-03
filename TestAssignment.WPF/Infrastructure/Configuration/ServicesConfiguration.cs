using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.Infrastructure.Services;
using TestAssignment.WPF.Infrastructure.Services.Interfaces;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class ServicesConfiguration
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
        } 
    }
}
