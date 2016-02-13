using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Funkysi1701.Website.Startup))]
namespace Funkysi1701.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
