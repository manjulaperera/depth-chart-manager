using DepthChartManager.Core;
using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
namespace DepthChartManager.Infrastructure
{
    public static class IocBootstrapper
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ISportRepository).Assembly);
            services.AddAutoMapper(typeof(ISportRepository).Assembly);
            services.AddSingleton<ISportRepository, SportRepository>();
        }
    }
}
