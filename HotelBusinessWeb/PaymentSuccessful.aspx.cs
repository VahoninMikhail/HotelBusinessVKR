using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using RestApiHotelBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelBusinessWeb
{
    public partial class PaymentSuccessful : System.Web.UI.Page
    {
        public IEnumerable<RoomOrderViewModel> GetCartLinesRoom()
        {
            return SessionHelper.GetCart(Session).LinesRoom;
        }

        public IEnumerable<ServiceOrderViewModel> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoViewModel list =
                     Task.Run(() => APIСlient.GetRequestData<UserInfoViewModel>("api/Account/UserInfo")).Result;


            List<UserViewModel> listUser =
                     Task.Run(() => APIСlient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
            string userId = "";
            foreach (var user in listUser)
            {
                if (user.UserName.Equals(APIСlient.UserName))
                {
                    userId = user.Id;
                }
            }

            List<ServiceOrderBindingModel> serviceBM = new List<ServiceOrderBindingModel>();
            foreach (var i in GetCartLines())
            {
                serviceBM.Add(new ServiceOrderBindingModel
                {
                    ServiceId = i.ServiceId,
                    Count = i.Count
                });
            }

            DateTime arrivalDate = DateTime.Today;
            DateTime departureDate = DateTime.Today;
            List<RoomOrderBindingModel> roomBM = new List<RoomOrderBindingModel>();
            foreach (var i in GetCartLinesRoom())
            {
                arrivalDate = i.ArrivalDate;
                departureDate = i.DepartureDate;

                roomBM.Add(new RoomOrderBindingModel
                {
                    ArrivalDate = i.ArrivalDate,
                    DepartureDate = i.DepartureDate,
                    RoomId = i.RoomId
                });
            }

            Task task = Task.Run(() => APIСlient.PostRequestData("api/Order/AddElement", new OrderBindingModel
            {
                UserId = userId,
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                RoomOrders = roomBM,
                ServiceOrders = serviceBM,
                Payed = CartTotal
            }));

            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>"),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }
    }
}