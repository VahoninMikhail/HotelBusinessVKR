using PekaMarketService.BindingModels;
using PekaMarketService.Implementations;
using PekaMarketService.Interfaces;
using PekaMarketService.ViewModels;
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
    public partial class FormProduct : System.Web.UI.Page
    {

        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    var Konserva = Task.Run(() => APIСlient.GetRequestData<ProductViewModel>("api/Product/Get/" + id)).Result;
                    textBoxName.Text = Konserva.ProductName;
                    textBoxPrice.Text = Konserva.Price.ToString();
                    
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
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<ProductViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<ProductViewModel>>("api/Product/GetList")).Result;
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.AutoGenerateSelectButton = true;
                    dataGridView.DataBind();

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название товара');</script>");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните цену товара');</script>");
                return;
            }
            Task task;
            string name = textBoxName.Text;
            int price = Convert.ToInt32(textBoxPrice.Text);

            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Product/UpdElement", new ProductBindingModel
                {
                    Id = id,
                    ProductName=name,
                    Price=price


                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Product/AddElement", new ProductBindingModel
                {
                    ProductName = name,
                    Price = price
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
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            Session["id"] = null;
            Server.Transfer("FormProduct.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text;
                Session["id"] = index;
                //var Konserva = Task.Run(() => APIСlient.GetRequestData<ProductViewModel>("api/Product/Get/" + Convert.ToInt32(index))).Result;
                //textBoxName.Text = Konserva.ProductName;
                //textBoxPrice.Text = Convert.ToInt32( Konserva.Price).ToString();
                Server.Transfer("FormProduct.aspx");

            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedIndex >= 0)
            {

                int id = Convert.ToInt32(dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text);
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Product/DelElement", new ProductBindingModel { Id = id }));

                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Запись удалена');</script>"),
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


                LoadData();

                Server.Transfer("FormProduct.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            LoadData();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormMain.aspx");
        }

    }
}