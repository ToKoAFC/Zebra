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
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            // Resolver for MVC.
            var mvc_resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvc_resolver);
            
        }
    }
}
