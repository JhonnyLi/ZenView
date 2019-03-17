using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenView.Startup))]
namespace ZenView
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
