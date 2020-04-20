using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Genix.Web.Routes
{
    public static class CustomeRoutesExtension
    {
        public static IServiceCollection RegisterRoutes(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(w =>
            {
                w.ViewLocationFormats.Add("/Views/Home/Partial/{0}.cshtml");
                w.ViewLocationFormats.Add("/Views/Notifications/{0}.cshtml");
            });

            return services;
        }
    }
}
