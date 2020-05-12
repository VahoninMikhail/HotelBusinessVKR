using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelBusinessWebForms.Startup))]
namespace HotelBusinessWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
