using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelBusinessWeb
{
    public partial class FormCreateOrder : System.Web.UI.Page
    {
        public List<RoomOrderViewModel> Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Model = new List<RoomOrderViewModel>();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<FormViewModel> list1 = Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                if (list1 != null)
                {
                    DropDownListForm.DataSource = list1;
                    DropDownListForm.DataTextField = "FormName";
                    DropDownListForm.DataValueField = "Id";
                    DropDownListForm.DataBind();
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
            if (Model != null)
            {
               // DropDownListForm.Enabled = false;
               // DropDownListForm.SelectedValue = Model.Id;
               // TextBoxCount.Text = Model.Count.ToString();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(TextBoxCount.Text);
            int formid = Convert.ToInt32(DropDownListForm.SelectedValue);

            List<RoomViewModel> listRoom = Task.Run(() => APIСlient.GetRequestData<List<RoomViewModel>>("api/Room/GetList")).Result;
            listRoom.RemoveAll(list => list.FormId != formid);
            for (int i = 0; i < count; i++)
            {
                Model.Add(new RoomOrderViewModel()
                { RoomId = listRoom[i].Id,
                  RoomName = listRoom[i].RoomName,
                });
            }
            Server.TransferRequest("FormMain.aspx");
        }

    }
}