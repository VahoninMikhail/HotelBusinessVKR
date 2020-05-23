using HotelBusinessWeb.App_Start;
using System;
using System.Web.Routing;

namespace HotelBusinessWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            APIСlient.Connect();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}