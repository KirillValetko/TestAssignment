using Microsoft.Extensions.DependencyInjection;
using TestAssignment.BLL.Infrastructure;
using TestAssignment.DAL.Infrastructure;

namespace TestAssignment.WPF.Infrastructure.Configuration
{
    public static class MapperConfiguration
    {
        public static void InitMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DalMapperProfiles), typeof(BllMapperProfiles), typeof(WpfMapperProfiles));
        }
    }
}
