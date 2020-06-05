using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HotelBusinessWeb
{
    public partial class Account : System.Web.UI.Page
    {
        public int myId;

        protected void Page_Load(object sender, EventArgs e)
        {
             /*if (!User.IsInRole("User"))
             {
                 Response.Redirect("FormLogin.aspx");
             }*/
            try
            {
                Label1.Text = "Количество бонусов: " + Convert.ToString(GetUserInfo()) + "";
                if (IsPostBack)
                {
                    int orderId;
                    if (int.TryParse(Request.Form["save"], out orderId))
                    {
                         SaveOrderPDF(orderId);
                    }
                    if (int.TryParse(Request.Form["PostReview"], out orderId))
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(Request.Form["inputText"])))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните отзыв');</script>");
                            return;
                        }
                        try
                        {
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

                            string text = Convert.ToString(Request.Form["inputText"]);
                            Task task = Task.Run(() => APIСlient.PostRequestData("api/Order/AddReview", new ReviewBindingModel
                            {
                                Text = text,
                                UserId = userId,
                                OrderId = orderId
                            }));
                            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Успешно отправлено');</script>"),
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
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if (APIСlient.UserName == null)
                {
                    Response.Redirect("FormLogin.aspx");
                }
            }
        }

        public void SaveOrderPDF(int orderId)
        {
            string TempPath = Task.Run(() => APIСlient.GetRequestData<string>("api/Order/GetTemp")).Result;
            FileStream sourceFile = new FileStream(TempPath + "Бронь" + orderId+ ".pdf", FileMode.Open);
            float FileSize;
            FileSize = sourceFile.Length;
            byte[] fileContent = new byte[(int)FileSize];
            sourceFile.Read(fileContent, 0, (int)sourceFile.Length);
            sourceFile.Close();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application / octet-stream";
            Response.AddHeader("Content-Length", fileContent.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename =" + sourceFile.Name);
            string fileName = sourceFile.Name;
            Response.BinaryWrite(fileContent);
            Response.Flush();
            Response.End();
        }

        public List<OrderViewModel> GetOrders()
        {
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

            return Task.Run(() => APIСlient.GetRequestData<List<OrderViewModel>>("api/Order/GetPosetitelList/"+ userId + "")).Result;
        }

        public int GetUserInfo()
        {
            List<UserViewModel> listUser =
                     Task.Run(() => APIСlient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
            string userId = "";
            int userBonuses = 0;
            foreach (var user in listUser)
            {
                if (user.UserName.Equals(APIСlient.UserName))
                {
                    userId = user.Id;
                    userBonuses = user.Bonuses;
                }
            }
            return userBonuses;
        }

        public OrderViewModel GetOrder(int id)
        {
            return Task.Run(() => APIСlient.GetRequestData<OrderViewModel>("api/Order/Get/" + id + "")).Result;
        }
    }
}