using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoTube.Startup))]
namespace CryptoTube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
