using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnRaoVat.Startup))]
namespace DoAnRaoVat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
