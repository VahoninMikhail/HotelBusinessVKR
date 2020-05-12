using PekaMarketService.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PekaMarketEmploeeWebView
{
    public partial class FormReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxUserName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле логин');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле ФИО');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text) && string.IsNullOrEmpty(TextBoxPassword1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Пароль');</script>");
                return;
            }
            if (!TextBoxPassword.Text.Equals(TextBoxPassword1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Пароли не совпадают');</script>");
                return;
            }
            string fio = TextBoxFIO.Text;
            string login = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;
            Task task;

                task = Task.Run(() => APIСlient.PostRequestData("api/Emloyee/AddElement", new EmployeeBindingModel
                {
                    EmployeeFIO=fio,
                    Login=login,
                    Password=password
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
    }
}