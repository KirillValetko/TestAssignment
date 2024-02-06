using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.Infrastructure.Configuration;

namespace TestAssignment.WPF
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.InitMainWindow();
                    services.InitViewModels();
                    services.InitGenerators();
                    services.InitServices();
                    services.InitNavigation();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
