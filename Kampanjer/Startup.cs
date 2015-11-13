using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kampanjer.Startup))]
namespace Kampanjer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
