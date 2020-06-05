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
            if (IsPostBack)
            {
                login.ServerClick += new EventHandler(Button1_Click1);
            }
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Server.Transfer("FormReg.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputEmail.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле логин');</script>");
                return;
            }
            if (string.IsNullOrEmpty(inputPassword.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле пароль');</script>");
                return;
            }
            try
            {
                APIСlient.Login(inputEmail.Value, inputPassword.Value);
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}