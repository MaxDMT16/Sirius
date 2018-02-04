using Autofac;
using SiriusCRM.Database.Context;

namespace SiriusCRM.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiriusDbContext>().AsImplementedInterfaces();
        }
    }
}