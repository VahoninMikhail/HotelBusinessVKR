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
    public partial class FormStorages : System.Web.UI.Page
    {
        public int Id { set { id = value; } }

        private int? id;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
           
                try
                {
                    List<StockViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<StockViewModel>>("api/Stock/GetList")).Result;
                    if (list != null)
                    {
                        dataGridView.DataSource = list;
                        dataGridView.AutoGenerateSelectButton = true;
                        dataGridView.DataBind();
                    
  
                    }
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

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormStorage.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text; ;
                Session["id"] = index;
                Server.Transfer("FormStorage.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >0)
            {
               
                    int id = Convert.ToInt32(dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text);

                    Task task = Task.Run(() => APIСlient.PostRequestData("api/Stock/DelElement", new StockBindingModel { Id = id }));

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
                
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FormStorages.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}