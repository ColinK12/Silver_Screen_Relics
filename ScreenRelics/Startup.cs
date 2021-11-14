using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScreenRelics.Startup))]
namespace ScreenRelics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
