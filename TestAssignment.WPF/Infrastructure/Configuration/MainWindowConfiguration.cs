using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.ViewModels;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class MainWindowConfiguration
    {
        public static void InitMainWindow(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }
    }
}
