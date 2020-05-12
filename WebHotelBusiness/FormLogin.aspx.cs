using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebHotelBusiness
{
    public partial class FormLogin : System.Web.UI.Page
    {
        public FormLogin()
        {
            APIСlient.Connect();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
                  < assemblies >
        < add assembly = "Microsoft.Build.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
 
         < add assembly = "Microsoft.ReportViewer.Common, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" />
  
          < add assembly = "Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" />
  
        </ assemblies >
        */
        }


        protected void Button2_Click(object sender, EventArgs e)
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
                APIСlient.fio_Employee = TextBoxUserName.Text;
                Server.Transfer("FormMain.aspx");


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}