using Autofac;
using SiriusCRM.Application.Buses;

namespace SiriusCRM.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces();
            builder.RegisterType<QueryBus>().AsImplementedInterfaces();
        }
    }
}