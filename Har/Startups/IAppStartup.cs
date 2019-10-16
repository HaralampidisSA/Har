using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Har.Startups
{
    public interface IAppStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void ConfigureModules(ContainerBuilder containerBuilder, IConfiguration configuration);

        void Configure(IApplicationBuilder application);

        int Order { get; }
    }
}