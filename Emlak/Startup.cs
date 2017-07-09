using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emlak.Startup))]
namespace Emlak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
