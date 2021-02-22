using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaVirtual.Startup))]
namespace TiendaVirtual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
