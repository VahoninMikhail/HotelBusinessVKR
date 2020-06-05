using HorelBusinessService.BindingModels;
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
    public partial class FormReg : System.Web.UI.Page
    {
        public FormReg()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Register.ServerClick += new EventHandler(Button1_Click1);
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputName.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле ФИО');</script>");
                return;
            }
            if (string.IsNullOrEmpty(inputEmail.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле email');</script>");
                return;
            }
            if (string.IsNullOrEmpty(inputTel.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле номер телефона');</script>");
                return;
            }
            if (string.IsNullOrEmpty(inputPassword.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле пароль');</script>");
                return;
            }
            if (string.IsNullOrEmpty(inputConfirm.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле подтвержение');</script>");
                return;
            }
            string fio = inputName.Value;
            string login = inputEmail.Value;
            string phoneNumber = inputTel.Value;
            string password = inputPassword.Value;
            string confirmPassword = inputConfirm.Value;

            try
            {
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Account/Register", new RegisterBindingModel
                {
                    UserFIO = fio,
                    Email = login,
                    PhoneNumber = phoneNumber,
                    Password = password,
                    ConfirmPassword = confirmPassword
                }));
                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Сохранение прошло успешно');</script>"),
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
                Server.Transfer("FormLogin.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormLogin.aspx");
        }
    }
}