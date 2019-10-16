using Autofac;
using Microsoft.Extensions.Configuration;

namespace Har.AspNetCore.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void ConfigureApplicationModules(this ContainerBuilder builder, IConfiguration configuration)
        {
            EngineContext.Current.ConfigureContainer(builder, configuration, new AppDomainTypeFinder());
        }
    }
}
