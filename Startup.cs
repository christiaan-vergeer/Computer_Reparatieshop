using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Computer_Reparatieshop.Startup))]
namespace Computer_Reparatieshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
