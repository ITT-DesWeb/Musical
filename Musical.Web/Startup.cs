using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Musical.Web.Startup))]
namespace Musical.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
