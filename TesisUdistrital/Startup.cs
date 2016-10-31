using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesisUdistrital.Startup))]
namespace TesisUdistrital
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
