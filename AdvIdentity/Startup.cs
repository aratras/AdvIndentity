using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdvIdentity.Startup))]
namespace AdvIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
