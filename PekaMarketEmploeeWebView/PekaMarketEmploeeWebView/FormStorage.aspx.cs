using PekaMarketService.BindingModels;
using PekaMarketService.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace PekaMarketEmploeeWebView
{
    public partial class FormStorage : System.Web.UI.Page
    {

        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {

                try
                {
                    var Stock = Task.Run(() => APIСlient.GetRequestData<StockViewModel>("api/Stock/Get/" + id)).Result;
                    textBoxFIO.Text = Stock.StockName;
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните name');</script>");
                return;
            }
            string fio = textBoxFIO.Text;
            Task task;
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Stock/UpdElement", new StockBindingModel
                {
                    Id = id,
                    StockName = textBoxFIO.Text,


                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Stock/AddElement", new StockBindingModel
                {
                    StockName = textBoxFIO.Text,
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



            Server.Transfer("FormStorages.aspx");
        }


        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormStorages.aspx");
        }
    }
}