
using PekaMarketService.BindingModels;
using PekaMarketService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.UI;

namespace PekaMarketEmploeeWebView
{
    public partial class FormClients : System.Web.UI.Page
    {
        public FormClients() {
            APIСlient.Connect();
        }

        protected void Page_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            try
            {
                List<ClientViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<ClientViewModel>>("api/Client/GetList")).Result;
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
            Server.Transfer("FormClient.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text;
                Session["id"] = index;
                Server.Transfer("FormClient.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {

                int id = Convert.ToInt32(dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text);
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Client/DelElement", new ClientBindingModel { Id = id }));

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
                
                Server.Transfer("FormClients.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FormClients.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}