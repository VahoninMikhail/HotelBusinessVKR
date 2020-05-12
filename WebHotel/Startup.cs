using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHotel.Startup))]
namespace WebHotel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
