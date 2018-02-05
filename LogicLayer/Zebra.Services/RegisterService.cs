using Autofac;
using System.Linq;
using Zebra.Database.Access;
using Zebra.Services.Interfaces;

namespace Zebra.Services
{
    public class RegisterService
    {
        public static void Register(ContainerBuilder builder, string nameOrConnectionString)
        {
            SetupIoC(builder, nameOrConnectionString);
        }
        private static void SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
        {
            RegisterAccess.Register(builder, nameOrConnectionString);
            builder.RegisterAssemblyTypes(typeof(IProductService).Assembly)
                .Where(t => t.Name.EndsWith("Service") && t.Namespace != null && t.Namespace.StartsWith("Zebra.Services"))                
                .AsImplementedInterfaces();
        }
    }
}


