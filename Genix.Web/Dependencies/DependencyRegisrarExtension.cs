using Genix.Data.Infrastructure;
using Genix.Data.Repository;
using Genix.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Genix.Web.Dependencies
{
    public static class DependencyRegisrarExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IDbContext), typeof(ObjectContext));

            return services;
        }
    }
}
