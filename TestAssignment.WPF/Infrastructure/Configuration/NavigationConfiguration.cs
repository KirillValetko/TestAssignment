using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.ViewModels;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class NavigationConfiguration
    {
        public static void InitNavigation(this IServiceCollection services)
        {
            services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider =>
                viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));
        }
    }
}
