using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaGestionRENI.Startup))]
namespace SistemaGestionRENI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
