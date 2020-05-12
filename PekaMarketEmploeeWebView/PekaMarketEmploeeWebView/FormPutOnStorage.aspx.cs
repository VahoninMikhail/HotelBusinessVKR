using PekaMarketService.BindingModels;
using PekaMarketService.Implementations;
using PekaMarketService.Interfaces;
using PekaMarketService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PekaMarketEmploeeWebView
{
    public partial class FormPutOnStorage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> listP = Task.Run(() => APIСlient.GetRequestData<List<ProductViewModel>>("api/Product/GetList")).Result;
                if (listP != null)
                {
                    DropDownListElement.DataSource = listP;
                    DropDownListElement.DataTextField = "ProductName";
                    DropDownListElement.DataValueField = "Id";
                    DropDownListElement.DataBind();

                }
                List<StockViewModel> listS = Task.Run(() => APIСlient.GetRequestData<List<StockViewModel>>("api/Stock/GetList")).Result;
                if (listS != null)
                {
                    
                    DropDownListStorage.DataSource = listS;
                    DropDownListStorage.DataTextField = "StockName";
                    DropDownListStorage.DataValueField = "Id";
                    DropDownListStorage.DataBind();
                }
                Page.DataBind();
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

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListElement.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите product');</script>");
                return;
            }
            if (DropDownListStorage.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите склад');</script>");
                return;
            }
            try
            {
                int componentId = Convert.ToInt32(DropDownListElement.SelectedValue);
                int stockId = Convert.ToInt32(DropDownListStorage.SelectedValue);
                int count = Convert.ToInt32(TextBoxCount.Text);
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Stock/PutProductOnStock", new ProductStockBindingModel
                {
                    ProductId= componentId,
                    StockId=stockId,
                    Count=count
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
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }

    }
}