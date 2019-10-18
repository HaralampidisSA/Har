using Autofac;
using System;
using System.Linq;

namespace Har.Dependency
{
    public class BasicConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(ContainerBuilder containerBuilder, ITypeFinder typeFinder)
        {
            var transients = typeFinder.FindClassesOfType<ITransientDependency>();
            //var transientInstances = transients.Select(Activator.CreateInstance);
            //foreach (var instance in transientInstances)
            //{
            //    containerBuilder.RegisterType(typeof(instance))
            //    // containerBuilder.RegisterGeneric(instance).AsImplementedInterfaces().InstancePerDependency();
            //}

            foreach (var transient in transients)
            {
                containerBuilder.RegisterType(transient).AsImplementedInterfaces().InstancePerDependency();
            }

            var singletons = typeFinder.FindClassesOfType<ISingletonDependency>();
            var singletonInstances = singletons.Select(Activator.CreateInstance);
            foreach (var instance in singletonInstances)
            {
                containerBuilder.RegisterInstance(instance).AsImplementedInterfaces().SingleInstance();
            }
        }
    }
}
