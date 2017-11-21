using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Zebra.Web
{
    public class IoCConfig
    {
        public static void SetupIoC(ContainerBuilder builder)
        {
            //Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();
                       
            // Build the container.
            var container = builder.Build();

            // Resolver for MVC.
            var mvc_resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvc_resolver);
            
        }
    }
}
