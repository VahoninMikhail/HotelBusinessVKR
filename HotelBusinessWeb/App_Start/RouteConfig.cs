using System.Web.Routing;

namespace HotelBusinessWeb.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{page}", "~/FormMain.aspx");
            routes.MapPageRoute(null, "", "~/FormMain.aspx");
            routes.MapPageRoute(null, "list", "~/FormMain.aspx");

            routes.MapPageRoute("cart", "cart", "~/CartView.aspx");
            routes.MapPageRoute("login", "login", "~/FormLogin.aspx");
            routes.MapPageRoute("register", "register", "~/FormReg.aspx");
            routes.MapPageRoute("account", "account", "~/Account.aspx");
            routes.MapPageRoute("main", "main", "~/FormMain.aspx");
        }
    }
}