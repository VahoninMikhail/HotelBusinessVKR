using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;


namespace PekaMarketEmploeeWebView
{
    public partial class FormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                List<OrderViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<OrderViewModel>>("api/Order/GetList")).Result;
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.AutoGenerateSelectButton = true;
                    dataGridView1.DataBind();
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

        protected void ButtonCreateIndent_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormCreateZakaz.aspx");
        }

     /*   protected void ButtonTakeIndentInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                string index = dataGridView1.SelectedIndex.ToString();
                Session["id"] = index;
                Server.Transfer("TakeIndentInWork.aspx");
            }
        }
        */
        protected void ButtonIndentReady_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedIndex].Cells[1].Text);

                Task task = Task.Run(() => APIСlient.PostRequest("api/Order/FinOrder/"+ id));

                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заказ готов');</script>"),
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

        protected void ButtonIndentPayed_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedIndex].Cells[1].Text);
                Task task = Task.Run(() => APIСlient.PostRequest("api/Order/PayOrder/"+ id));

                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Статус заказа изменён');</script>"),
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
            Server.Transfer("FormMain.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() => APIСlient.PostRequest("api/Serialize/GetData" ));

            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('бэкап сохранён');</script>"),
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
}