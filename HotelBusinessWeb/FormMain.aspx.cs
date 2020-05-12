using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;

namespace HotelBusinessWeb
{
    public partial class FormMain : System.Web.UI.Page
    {
        private List<ServiceViewModel> services = new List<ServiceViewModel>();

        private List<RoomOrderViewModel> roomOrders = new List<RoomOrderViewModel>();
        private List<ServiceOrderViewModel> serviceOrders = new List<ServiceOrderViewModel>();

        protected void Page_Init(object sender, EventArgs e)
        {
            serviceOrders = new List<ServiceOrderViewModel>();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
           /* if (!Page.IsPostBack)
            {
                roomOrders = new List<RoomOrderViewModel>();
                serviceOrders = new List<ServiceOrderViewModel>();
            }*/
        }

        private void LoadData()
        { 
            try
             {
                 /*List<FormViewModel> list1 = Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                 if (list1 != null)
                 {
                     DropDownListForm.DataSource = list1;
                     DropDownListForm.DataTextField = "FormName";
                     DropDownListForm.DataValueField = "Id";
                     DropDownListForm.DataBind();
                 }*/

                 List<ServiceViewModel> listService = Task.Run(() => APIСlient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList")).Result;
                if (listService != null)
                {
                    GridViewService.DataSource = listService;
                    GridViewService.AutoGenerateSelectButton = true;
                    GridViewService.DataBind();
                }
                List<FormViewModel> listForm = Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                if (listForm != null)
                {
                    GridViewForm.DataSource = listForm;
                    GridViewForm.AutoGenerateSelectButton = true;
                    GridViewForm.DataBind();
                }
            }
             catch (Exception ex)
             {
                 while (ex.InnerException != null)
                 {
                     ex = ex.InnerException;
                 }
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
             }
        }



        private void InitializeComponent()
        {
            InitializeComponent();
        }

        protected void ButtonAddForm_Click(object sender, EventArgs e)
        {

        }
            

        protected void Save_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridViewForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* roomOrders.RemoveRange(0, roomOrders.Count);
             int formid = Convert.ToInt32(GridViewForm.SelectedValue);
             int count = Convert.ToInt32(TextBoxCountForm.Text);

             List<RoomViewModel> listRoom = Task.Run(() => APIСlient.GetRequestData<List<RoomViewModel>>("api/Room/GetList")).Result;
             listRoom.RemoveAll(list => list.FormId != formid);
             for (int i = 0; i < count; i++)
             {
                 roomOrders.Add(new RoomOrderViewModel()
                 {
                     RoomId = listRoom[i].Id,
                     RoomName = listRoom[i].RoomName,
                 });
             }

             try
             {
                 if (roomOrders != null)
                 {
                     GridViewZakazRoom.DataSource = null;
                     GridViewZakazRoom.DataSource = roomOrders;
                     //GridViewZakazRoom.AutoGenerateSelectButton = true;
                     GridViewZakazRoom.DataBind();
                 }
             }
             catch (Exception ex)
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
             }*/
            try
            {
                if (IsPostBack)
                {
                    int formid = Convert.ToInt32(GridViewForm.SelectedValue);
                    int count = Convert.ToInt32(TextBoxCountForm.Text);

                    DateTime fromDate = CalendarFrom.SelectedDate;
                    DateTime beforeDate = CalendarBefore.SelectedDate;

                    if (formid != 0)
                    {
                        SessionHelper.GetCart(Session).AddRoomItem(formid, count, fromDate, beforeDate);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridViewService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int serviceid = Convert.ToInt32(GridViewService.SelectedValue);
                int count = Convert.ToInt32(TextBoxCountService.Text);
                // if (int.TryParse(Request.. Form["GridViewService"], out selectedServiceId))
                //  {
               // ServiceViewModel selectedService = services
               //     .Where(g => g.Id == serviceid).FirstOrDefault();

                if (serviceid != 0)
                {
                    SessionHelper.GetCart(Session).AddItem(serviceid, count);
                    SessionHelper.Set(Session, SessionKey.RETURN_URL,
                        Request.RawUrl);

                    /* Response.Redirect(RouteTable.Routes
                         .GetVirtualPath(null, "cart", null).VirtualPath);*/
                }
                // }
            }

            /*   //serviceOrders.RemoveRange(0, serviceOrders.Count);
               int serviceid = Convert.ToInt32(GridViewService.SelectedValue);
               int count = Convert.ToInt32(TextBoxCountService.Text);
               ServiceViewModel service = Task.Run(() => APIСlient.GetRequestData<ServiceViewModel>("api/Service/Get/" + serviceid)).Result;
               serviceOrders.Add(new ServiceOrderViewModel()
               {
                   ServiceId = service.Id,
                   ServiceName = service.ServiceName,
                   Count = count,
                   Price = service.Price,
                   Total = service.Price * count
               });

               try
               {
                   if (serviceOrders != null)
                   {
                       GridViewZakazService.DataSource = serviceOrders;
                       //GridViewZakazService.AutoGenerateSelectButton = true;
                       GridViewZakazService.DataBind();
                   }
               }
               catch (Exception ex)
               {
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
               }*/
        }

        protected void GridViewService_PreRender(object sender, EventArgs e)
        {
          //  serviceOrders = new List<ServiceOrderViewModel>();
        }
    }
}
