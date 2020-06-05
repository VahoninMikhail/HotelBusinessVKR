using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (GetCartLinesRoom().GetEnumerator().MoveNext() == true)
            {
                CalendarFrom.SelectedDate = GetCartLinesRoom().ElementAt(0).ArrivalDate;
                CalendarBefore.SelectedDate = GetCartLinesRoom().ElementAt(0).DepartureDate;
                CalendarFrom.Visible = false;
                CalendarBefore.Visible = false;
                search.Visible = false;
                secectNewDate.Visible = true;
                forms.Visible = true;
                LabelDate.Text = "Выбраны даты: С " + CalendarFrom.SelectedDate + " По " + CalendarBefore.SelectedDate;
                LabelDate.Visible = true;
            }
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
                        forms.Visible = false;
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
            SessionHelper.GetCart(Session).RemoveAllServices();
        }

        public IEnumerable<RoomOrderViewModel> GetCartLinesRoom()
        {
            return SessionHelper.GetCart(Session).LinesRoom;
        }

        void ButtonNext_Click(Object sender, EventArgs e)
        {
            string s = "Выберите номер";
            if(GetCartLinesRoom().GetEnumerator().MoveNext() == true)
            {
                serv.Visible = true;
                forms.Visible = false;
            }
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + s + "');</script>");
        }

        void ButtonSecectNewDate_Click(Object sender, EventArgs e)
        {
            CalendarFrom.Visible = true;
            CalendarBefore.Visible = true;
            search.Visible = true;
            secectNewDate.Visible = false;

            forms.Visible = false;
            serv.Visible = false;

            LabelDate.Visible = false;

            SessionHelper.GetCart(Session).RemoveAll();
        }

        void ButtonSearch_Click(Object sender, EventArgs e)
        {
            if (CalendarFrom.SelectedDate == null || CalendarBefore.SelectedDate == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите даты');</script>");
                return;
            }
            if (CalendarFrom.SelectedDate < DateTime.Now.Date || CalendarFrom.SelectedDate >= CalendarBefore.SelectedDate || CalendarBefore.SelectedDate <= DateTime.Now.Date)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Дата въезда не может быть меньше даты выезда и текущей даты');</script>");
                return;
            }
            CalendarFrom.Visible = false;
            CalendarBefore.Visible = false;
            search.Visible = false;
            secectNewDate.Visible = true;

            forms.Visible = true;
            LabelDate.Text = "Выбраны даты: С " + CalendarFrom.SelectedDate + " По " + CalendarBefore.SelectedDate;
            LabelDate.Visible = true;
        }

        public List<FormViewModel> GetForms()
        {
            return Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
        }

        public List<string> ImageList(int id)
        {
            FormViewModel form = Task.Run(() => APIСlient.GetRequestData<FormViewModel>("api/Form/Get/" + id + "")).Result;

            List<ImageViewModel> im = form.Images;
            if (form != null)
            {
                List<string> imList = new List<string>();
                foreach (var i in im)
                {
                    string r = Convert.ToBase64String(i.Image);
                    string imgDataURL = string.Format("data:image/png;base64,{0}", r);
                    imList.Add(imgDataURL);
                }
                return imList;
            }
            else
            {
                return null;
            }
        }

        public List<string> ServiceNames(int id)
        {
            FormViewModel form = Task.Run(() => APIСlient.GetRequestData<FormViewModel>("api/Form/Get/" + id + "")).Result;

            List<FormFreeServiceViewModel> FreeServices = form.FormFreeServices;
            if (form != null)
            {
                List<string> serviceNames = new List<string>();
                foreach (var i in FreeServices)
                {
                    serviceNames.Add(i.ServiceName);
                }
                return serviceNames;
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
