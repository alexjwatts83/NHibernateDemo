using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernateDemo.Infrastructure.Config;

namespace NHibernateDemo.Infrastructure
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));

            return services;
        }
    }
}
