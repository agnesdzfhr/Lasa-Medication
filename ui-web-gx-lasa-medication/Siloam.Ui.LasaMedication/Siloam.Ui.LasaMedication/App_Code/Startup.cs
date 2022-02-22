using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Siloam.Ui.LasaMedication.Startup))]
namespace Siloam.Ui.LasaMedication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
