using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelBusinessWeb.Controls
{
    public partial class GetOrder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<OrderViewModel> getOrder(int id)
        {
            return Task.Run(() => APIСlient.GetRequestData<List<OrderViewModel>>("api/Order/Get/" + id + "")).Result;
        }
    }
}