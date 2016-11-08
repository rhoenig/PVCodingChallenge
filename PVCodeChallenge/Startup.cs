using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PVCodeChallenge.Startup))]
namespace PVCodeChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
