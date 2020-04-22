using Genix.Data.Infrastructure;
using Genix.Data.Repository;
using Genix.Services;
using Genix.Services.Infrastructure.Authentication;
using Genix.Services.Infrastructure.Customers;
using Genix.Services.Infrastructure.Messages;
using Genix.Services.Services.Authentication;
using Genix.Services.Services.Customers;
using Genix.Services.Services.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));

            services.TryAddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            services.TryAddSingleton(typeof(ITempDataDictionaryFactory), typeof(TempDataDictionaryFactory));

            return services;
        }

        public static IServiceCollection AddCookies(this IServiceCollection services)
        {
            services.AddAuthentication(GenixAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(GenixAuthenticationDefaults.AuthenticationScheme, w =>
                {
                    w.LoginPath = "/Views/SignIn/SignIn/";
                    w.LogoutPath = "/Views/SignIn/SignOut/";
                });
            return services;
        }
    }
}
