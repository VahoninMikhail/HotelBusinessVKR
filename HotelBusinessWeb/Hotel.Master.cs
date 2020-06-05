using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelBusinessWeb
{
    public partial class Hotel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(APIСlient.UserName!=null)
            {
                LabelName.Text = "Здравствуйте  " + APIСlient.UserName;
            }
        }

        public string ReturnLogin
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "login", null).VirtualPath;
            }
        }

        public string ReturnRegister
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "register", null).VirtualPath;
            }
        }

        public string ReturnAccount
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "account", null).VirtualPath;
            }
        }

        public string ReturnMain
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "main", null).VirtualPath;
            }
        }
    }
}