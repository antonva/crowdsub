using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdSubMain.Startup))]
namespace CrowdSubMain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
