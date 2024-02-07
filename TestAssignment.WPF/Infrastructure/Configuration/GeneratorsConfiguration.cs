using Microsoft.Extensions.DependencyInjection;
using TestAssignment.Common.Generators;
using TestAssignment.Common.Generators.Interfaces;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class GeneratorsConfiguration
    {
        public static void InitGenerators(this IServiceCollection services)
        {
            services.AddScoped<IDateGenerator, DateGenerator>();
            services.AddScoped<IStringGenerator, StringGenerator>();
            services.AddScoped<IRowGenerator, RowGenerator>();
            services.AddScoped<IFileGenerator, FileGenerator>();
        }
    }
}
