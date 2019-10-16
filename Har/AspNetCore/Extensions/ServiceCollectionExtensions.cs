using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Har.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            var engine = EngineContext.Create();
            engine.ConfigureEngineServices(services, configuration);


        }
    }
}
