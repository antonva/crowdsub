using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdSub.Startup))]
namespace CrowdSub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
