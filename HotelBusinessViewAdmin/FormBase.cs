using HorelBusinessService.ViewModels;
using HotelBusinessViewAdmin.Autorization;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin
{
    public partial class FormBase : Form
    {
        private FormAuthorization parent;

        public FormBase(FormAuthorization parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelUserName.Text += ApiClient.UserName;
        }

        private void buttonForm_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Forms.Forms();
            if (form.ShowDialog() == DialogResult.OK)
            {
               
            }
        }

        private void buttonServices_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Services.Services();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonRooms_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Rooms.Rooms();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonUsers_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Users.Users();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonCreateOrder_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Orders.CreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonAdmins_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Admins.Admins();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void FormBase_Load(object sender, System.EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                List<OrderViewModel> list = await ApiClient.GetRequestData<List<OrderViewModel>>("api/Order/GetList");
                if (list != null)
                {
                    dataGridViewOrders.DataSource = null;
                    list.RemoveAll(r => Convert.ToDateTime(r.ArrivalDate) == dateTimePickerOrder.Value);
                    dataGridViewOrders.DataSource = list;
                   // dataGridViewRooms.Columns[0].Visible = false;
                    //dataGridViewRooms.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerOrder_ValueChanged(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}
