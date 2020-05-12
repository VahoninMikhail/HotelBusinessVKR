using PekaMarketService.BindingModels;
using PekaMarketService.Implementations;
using PekaMarketService.Interfaces;
using PekaMarketService.ViewModels;
using PekaMarketWebView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PekaMarketEmploeeWebView
{
    public partial class FormCreateZakaz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> listP = Task.Run(() => APIСlient.GetRequestData<List<ProductViewModel>>("api/Product/GetList")).Result;
                if (listP != null)
                {
                    DropDownListProduct.DataSource = listP;
                    DropDownListProduct.DataBind();
                    DropDownListProduct.DataTextField = "ProductName";
                    DropDownListProduct.DataValueField = "Id";
                }
                
                    List<ClientViewModel> listC = Task.Run(() => APIСlient.GetRequestData<List<ClientViewModel>>("api/Client/GetList")).Result; ;
                    if (listC != null)
                    {
                        DropDownListClient.DataSource = listC;
                        DropDownListClient.DataBind();
                        DropDownListClient.DataTextField = "ClientFIO";
                        DropDownListClient.DataValueField = "Id";
                    }
                
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Что-то пошло не так');</script>");
                }

                Page.DataBind();

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

        private void CalcSum()
        {

            if (DropDownListProduct.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {

                try
                {
                   int id = Convert.ToInt32(DropDownListProduct.SelectedValue);

                    ProductViewModel product = Task.Run(() => APIСlient.GetRequestData<ProductViewModel>("api/Product/Get/" + id)).Result;
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxPrice.Text = (count * (int)product.Price).ToString();
                    Page.DataBind();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }


        protected void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }


        protected void DropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (DropDownListClient.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите клиента');</script>");
                return;
            }
            int clientId = Convert.ToInt32(DropDownListClient.SelectedValue);
            int employeeId = 0;
            int productid = Convert.ToInt32(DropDownListProduct.SelectedValue);
            int count = Convert.ToInt32(TextBoxCount.Text);
            int summ = Convert.ToInt32(TextBoxPrice.Text);
            Task task = Task.Run(() => APIСlient.PostRequestData("api/Order/CreateOrder", new OrderBindingModel
            {
                ClientId = clientId,
                EmployeeId= employeeId,
                ProductId= productid,
                Count=count,
                Sum=summ
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
    }

    
}