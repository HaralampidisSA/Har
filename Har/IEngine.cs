using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Har
{
    public interface IEngine
    {
        void ConfigureEngineServices(IServiceCollection services, IConfiguration configuration);

        void ConfigureContainer(ContainerBuilder containerBuilder, IConfiguration configuration, ITypeFinder typeFinder);

        void ConfigureEngineRequestPipeline(IApplicationBuilder application);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        object ResolveUnregistered(Type type);
    }
}
