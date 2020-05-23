using System;
using System.Linq;
using System.Web.Routing;

namespace HotelBusinessWeb.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            removeAll.ServerClick += new EventHandler(ButtonRemoveAll_Click);
        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Cart myCart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = myCart.Lines.Sum(x => x.Count).ToString();
            csRoomQuantity.InnerText = myCart.LinesRoom.Count().ToString();
            csTotal.InnerText = myCart.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
        }

        void ButtonRemoveAll_Click(Object sender, EventArgs e)
        {
            SessionHelper.GetCart(Session).RemoveAll();
        }
    }
}