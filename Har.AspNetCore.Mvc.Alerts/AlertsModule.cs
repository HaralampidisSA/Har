using Autofac;
using Har.AspNetCore.Mvc.Alerts.Services;

namespace Har.AspNetCore.Mvc.Alerts
{
    public class AlertsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AlertService>().As<IAlertService>().InstancePerLifetimeScope();
        }


    }
}
