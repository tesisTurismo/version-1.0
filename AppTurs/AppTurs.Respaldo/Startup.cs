using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppTurs.Respaldo.Startup))]
namespace AppTurs.Respaldo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
