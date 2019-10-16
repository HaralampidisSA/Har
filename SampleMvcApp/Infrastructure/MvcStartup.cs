using Autofac;
using Har.AspNetCore.Mvc.Alerts;
using Har.Startups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleMvcApp.Infrastructure
{
    public class MvcStartup : IAppStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder application)
        {
            application.UseRouting();

            application.UseEndpoints(end =>
            {
                end.MapDefaultControllerRoute();
            });
        }

        public void ConfigureModules(ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            containerBuilder.RegisterModule(new AlertsModule());
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
        }
    }
}
