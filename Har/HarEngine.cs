using Autofac;
using Autofac.Extensions.DependencyInjection;
using Har.Exceptions;
using Har.Startups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Har
{
    public class HarEngine : IEngine
    {
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder containerBuilder, IConfiguration configuration, ITypeFinder typeFinder)
        {
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            var configs = typeFinder.FindClassesOfType<IAppStartup>();
            var instances = configs.Select(t => (IAppStartup)Activator.CreateInstance(t)).OrderBy(o => o.Order);
            foreach (var instance in instances)
            {
                instance.ConfigureModules(containerBuilder, configuration);
            }
        }

        public void ConfigureContainer(IServiceCollection services, IConfiguration configuration, ITypeFinder typeFinder)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            containerBuilder.Populate(services);

            var configs = typeFinder.FindClassesOfType<IAppStartup>();
            var instances = configs.Select(t => (IAppStartup)Activator.CreateInstance(t)).OrderBy(o => o.Order);
            foreach (var instance in instances)
            {
                instance.ConfigureModules(containerBuilder, configuration);
            }

            AutofacContainer = containerBuilder.Build();
        }

        public void ConfigureEngineRequestPipeline(IApplicationBuilder application)
        {
            AutofacContainer = application.ApplicationServices.GetAutofacRoot();

            var typeFinder = Resolve<ITypeFinder>();

            var startupConfigurations = typeFinder.FindClassesOfType<IAppStartup>();

            var instances = startupConfigurations.Select(startup => (IAppStartup)Activator.CreateInstance(startup)).OrderBy(startup => startup.Order);

            foreach (var instance in instances)
            {
                instance.Configure(application);
            }
        }

        public void ConfigureEngineServices(IServiceCollection services, IConfiguration configuration)
        {
            var typeFinder = new AppDomainTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<IAppStartup>();

            var instances = startupConfigurations.Select(startup => (IAppStartup)Activator.CreateInstance(startup)).OrderBy(startup => startup.Order);

            foreach (var instance in instances)
            {
                instance.ConfigureServices(services, configuration);
            }

            // ConfigureContainer(services, configuration, typeFinder);
        }

        public T Resolve<T>() where T : class
        {
            return AutofacContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return AutofacContainer.Resolve(type);
        }

        public object ResolveUnregistered(Type type)
        {
            Exception innerException = null;

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                try
                {
                    //try to resolve constructor parameters
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                            throw new HarException("Unknown dependency");
                        return service;
                    });

                    //all is ok, so create instance
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }
            throw new HarException("No constructor was found that had all the dependencies satisfied.", innerException);
        }
    }
}
