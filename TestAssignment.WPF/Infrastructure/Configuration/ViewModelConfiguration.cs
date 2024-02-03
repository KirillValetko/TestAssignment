using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.ViewModels;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class ViewModelConfiguration
    {
        public static void InitViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<FirstTaskViewModel>();
            services.AddSingleton<SecondTaskViewModel>();
        }
    }
}
