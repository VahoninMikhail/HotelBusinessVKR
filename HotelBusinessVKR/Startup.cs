using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelBusinessVKR.Startup))]
namespace HotelBusinessVKR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
