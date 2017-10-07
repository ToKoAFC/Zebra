using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zebra.Web.Startup))]
namespace Zebra.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
