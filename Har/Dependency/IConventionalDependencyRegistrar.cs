using Autofac;

namespace Har.Dependency
{
    public interface IConventionalDependencyRegistrar
    {
        void RegisterAssembly(ContainerBuilder containerBuilder, ITypeFinder typeFinder);
    }
}
