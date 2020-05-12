using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelBusinessWeb
{
    public partial class FormLogin : System.Web.UI.Page
    {
        public FormLogin()
        {
            //APIСlient.Connect();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Server.Transfer("FormReg.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxUserName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле логин');</script>");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле пароль');</script>");
                return;
            }
            try
            {
                APIСlient.Login(TextBoxUserName.Text, textBoxPassword.Text);
                APIСlient.UserName = TextBoxUserName.Text;
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}