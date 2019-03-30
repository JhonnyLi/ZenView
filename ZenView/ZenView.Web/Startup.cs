using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenView.Web.Startup))]
namespace ZenView.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
