using Microsoft.Extensions.DependencyInjection;
using OpenLicence.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OpenLicence.Infra.IoC
{
    public static class Injector
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpenLicenceContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Default")));
            return services;
        }
    }
}
