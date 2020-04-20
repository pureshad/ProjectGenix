using Genix.Data.Infrastructure;
using Genix.Data.Repository;
using Genix.Services;
using Genix.Services.Infrastructure.Authentication;
using Genix.Services.Infrastructure.Customers;
using Genix.Services.Services.Authentication;
using Genix.Services.Services.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Genix.Web.Dependencies
{
    public static class DependencyRegisrarExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IDbContext), typeof(ObjectContext));

            services.AddScoped(typeof(ICustomerRegitrationService), typeof(CustomerRegitrationService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IGenixAuthenticationService), typeof(GenixAuthenticationService));
            services.TryAddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            return services;
        }
    }
}
