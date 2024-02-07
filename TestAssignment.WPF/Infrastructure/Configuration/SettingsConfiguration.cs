using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAssignment.Common.Constants;
using TestAssignment.DAL.Infrastructure.Settings;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class SettingsConfiguration
    {
        public static void InitSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileDbSettings>(opt =>
            {
                opt.ConnectionString = configuration.GetConnectionString(DbSettingConstants.FileDb);
            });
            services.Configure<BalanceDbSettings>(opt =>
            {
                opt.ConnectionString = configuration.GetConnectionString(DbSettingConstants.BalanceDb);
            });
        }
    }
}
