using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GVB.Startup))]
namespace GVB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
