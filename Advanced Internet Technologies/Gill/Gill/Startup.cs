using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gill.Startup))]
namespace Gill
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
