using Autofac;
using Har.Domain.Repositories;
using SampleMvcApp.Data.Repos;

namespace SampleMvcApp.Modules
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(InMemoryRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();

            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}
