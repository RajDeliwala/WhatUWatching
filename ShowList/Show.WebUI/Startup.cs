using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Show.WebUI.Startup))]
namespace Show.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
