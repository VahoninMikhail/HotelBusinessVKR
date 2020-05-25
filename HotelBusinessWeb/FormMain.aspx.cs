using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HotelBusinessWeb
{
    public partial class FormMain : System.Web.UI.Page
    {
        private List<ServiceViewModel> services = new List<ServiceViewModel>();

        private List<RoomOrderViewModel> roomOrders = new List<RoomOrderViewModel>();
        private List<ServiceOrderViewModel> serviceOrders = new List<ServiceOrderViewModel>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            serviceOrders = new List<ServiceOrderViewModel>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                search.ServerClick += new EventHandler(ButtonSearch_Click);
                secectNewDate.ServerClick += new EventHandler(ButtonSecectNewDate_Click);
                next.ServerClick += new EventHandler(ButtonNext_Click);
                last.ServerClick += new EventHandler(ButtonLast_Click);

                //добавление номеров  в корзину
                try
                {
                    int formId;
                    if (int.TryParse(Request.Form["addForm"], out formId))
                    {
                        int count = Convert.ToInt32(Request.Form["addFormCount" + formId]);

                        DateTime fromDate = CalendarFrom.SelectedDate;
                        DateTime beforeDate = CalendarBefore.SelectedDate;
                        if (formId != 0)
                        {
                            SessionHelper.GetCart(Session).AddRoomItem(formId, Convert.ToInt32(count), fromDate, beforeDate);
                            SessionHelper.Set(Session, SessionKey.RETURN_URL,
                                Request.RawUrl);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                //добавление услуг в корзину
                try
                {
                    int serviceId;
                    if (int.TryParse(Request.Form["addService"], out serviceId))
                    {
                        int count = Convert.ToInt32(Request.Form["addServiceCount" + serviceId]);

                        if (serviceId != 0)
                        {
                            SessionHelper.GetCart(Session).AddItem(serviceId, count);
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
        }

        void ButtonLast_Click(Object sender, EventArgs e)
        {
            serv.Visible = false;
            forms.Visible = true;
        }

        void ButtonNext_Click(Object sender, EventArgs e)
        {
            serv.Visible = true;
            forms.Visible = false;
        }

        void ButtonSecectNewDate_Click(Object sender, EventArgs e)
        {
            CalendarFrom.Visible = true;
            CalendarBefore.Visible = true;
            search.Visible = true;
            secectNewDate.Visible = false;

            forms.Visible = false;
            serv.Visible = false;

         //   GridViewService.Visible = false;
         //   GridViewForm.Visible = false;

            LabelDate.Visible = false;

            SessionHelper.GetCart(Session).RemoveAll();
        }

        void ButtonSearch_Click(Object sender, EventArgs e)
        {          
            CalendarFrom.Visible = false;
            CalendarBefore.Visible = false;
            search.Visible = false;
            secectNewDate.Visible = true;
          //  LoadData();

            forms.Visible = true;

           // GridViewService.Visible = true;
          //  GridViewForm.Visible = true;

            LabelDate.Text = "Выбраны даты: С " + CalendarFrom.SelectedDate + " По " + CalendarBefore.SelectedDate;
            LabelDate.Visible = true;
        }

        public List<FormViewModel> GetForms()
        {
            return Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
        }

        public string Image(int id)
        {
            FormViewModel form = Task.Run(() => APIСlient.GetRequestData<FormViewModel>("api/Form/Get/" + id + "")).Result;

            ImageViewModel im = form.Images[0];
            if (form != null)
            {
                string r = Convert.ToBase64String(im.Image);
                string imgDataURL = string.Format("data:image/png;base64,{0}", r);
                return imgDataURL;
            }
            else
            {
                return null;
            }
        }

    /*    public string GetImage(int formId)
        {
            FormViewModel form = Task.Run(() => APIСlient.GetRequestData<FormViewModel>("api/Form/Get/" + formId + "")).Result;

            if (form != null)
            {
                string r = Convert.ToBase64String(form.Images[0].Image);
                string imgDataURL = string.Format("data:image/jpeg;base64,{0}", r);
                return imgDataURL;
            }
            else
            {
                return null;
            }
        }
        */
        public List<ServiceViewModel> GetServices()
        {
            return Task.Run(() => APIСlient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList")).Result;
        }

        private void InitializeComponent()
        {
            InitializeComponent();
        }

      /*  protected void GridViewForm_SelectedIndexChanged(object sender, EventArgs e)
        {           
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
        }*/

      /*  protected void GridViewService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int serviceid = Convert.ToInt32(GridViewService.SelectedValue);
                int count = Convert.ToInt32(TextBoxCountService.Text);
                if (serviceid != 0)
                {
                    SessionHelper.GetCart(Session).AddItem(serviceid, count);
                    SessionHelper.Set(Session, SessionKey.RETURN_URL,
                        Request.RawUrl);
                }
            }
        }*/
    }
}
