using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.net_mvc_webapp.Startup))]
namespace asp.net_mvc_webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
