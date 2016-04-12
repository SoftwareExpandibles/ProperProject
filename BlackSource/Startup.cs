using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackSource.Startup))]
namespace BlackSource
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
