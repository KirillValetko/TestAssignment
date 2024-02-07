using System.IO;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAssignment.WPF.Infrastructure.Configuration;

namespace TestAssignment.WPF
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddUserSecrets(GetType().Assembly, optional: false, reloadOnChange: true);
                    Configuration = configuration.Build();
                })
                .ConfigureServices((_, services) =>
                {
                    services.InitMainWindow();
                    services.InitViewModels();
                    services.InitGenerators();
                    services.InitSettings(Configuration);
                    services.InitDbContext();
                    services.InitRepositories();
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
