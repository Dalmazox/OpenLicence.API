using Microsoft.Extensions.DependencyInjection;
using OpenLicence.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenLicence.Domain.Interfaces.UoW;
using OpenLicence.Infra.Data.UoW;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Application.Services;
using OpenLicence.Domain.Interfaces.Builders;
using OpenLicence.Application.Builders;
using OpenLicence.Domain.Interfaces.Helpers;
using OpenLicence.Application.Helpers;

namespace OpenLicence.Infra.IoC
{
    public static class Injector
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpenLicenceContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Default")));
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<ISoftwareHouseService, SoftwareHouseService>()
                .AddTransient<IResponseBuilder, ResponseBuilder>()
                .AddTransient<IResponseHelper, ResponseHelper>();

            return services;
        }
    }
}
