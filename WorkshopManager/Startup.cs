using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkshopManager.Startup))]
namespace WorkshopManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
