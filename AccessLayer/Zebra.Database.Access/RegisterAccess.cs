using Autofac;
using System.Linq;
using Zebra.Database.Access.Interfaces;

namespace Zebra.Database.Access
{
    public class RegisterAccess
    {
        public static void Register(ContainerBuilder builder, string nameOrConnectionString)
        {
            SetupIoC(builder, nameOrConnectionString);
        }

        private static void SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
        {
            builder.RegisterType<ZebraContext>()
                .AsSelf()
                .WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IProductAccess).Assembly)
                .Where(t => t.Name.EndsWith("Access") && t.Namespace != null && t.Namespace.StartsWith("Zebra.Database.Access"))
                .AsImplementedInterfaces();            
        }
    }
}


