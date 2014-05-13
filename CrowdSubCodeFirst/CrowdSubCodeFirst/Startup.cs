using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdSubCodeFirst.Startup))]
namespace CrowdSubCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
