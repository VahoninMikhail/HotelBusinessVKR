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
    public partial class Change : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Content/Js/jquery-3.2.1.min.js",
            });
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле пароль');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBoxNewPassword.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле новый пароль');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBoxConfirmPassword.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле подтверждение пароля');</script>");
                return;
            }
            string password = TextBoxPassword.Text;
            string newPassword = TextBoxNewPassword.Text;
            string confirmPassword = TextBoxConfirmPassword.Text;

            try
            {
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Account/ChangePassword", new ChangePasswordBindingModel
                {
                    OldPassword = password,
                    NewPassword = newPassword,
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
    }
}