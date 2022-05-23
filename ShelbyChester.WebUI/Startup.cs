using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShelbyChester.WebUI.Startup))]
namespace ShelbyChester.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
