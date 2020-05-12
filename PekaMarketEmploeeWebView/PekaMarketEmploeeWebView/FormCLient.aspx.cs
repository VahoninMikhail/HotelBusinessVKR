using PekaMarketService.BindingModels;
using PekaMarketService.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace PekaMarketEmploeeWebView
{
    public partial class FormClient : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {

                try
                {
                    var klient = Task.Run(() => APIСlient.GetRequestData<ClientViewModel>("api/Client/Get/" + id)).Result;
                    textBoxFIO.Text = klient.ClientFIO;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            string fio = textBoxFIO.Text;
            Task task;
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Client/UpdElement", new ClientBindingModel
                {
                    Id = id,
                    ClientFIO = textBoxFIO.Text,


                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Client/AddElement", new ClientBindingModel
                {
                    ClientFIO = textBoxFIO.Text,
                }));
            }
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

            
            
            Server.Transfer("FormClients.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormClients.aspx");
        }
    }
}