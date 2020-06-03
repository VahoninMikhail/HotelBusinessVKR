using HorelBusinessService.ViewModels;
using HotelBusinessViewAdmin.Autorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
            InitializeExit();
        }

        private async void Initialize()
        {
            try
            {
                List<OrderViewModel> listEntry = await ApiClient.GetRequestData<List<OrderViewModel>>("api/Order/GetList");
                List<OrderViewModel> listExit = listEntry;
                if (listEntry != null)
                {
                    dataGridViewEntry.DataSource = null;
                    listEntry.RemoveAll(r => Convert.ToDateTime(r.ArrivalDate).Date != dateTimePickerEntry.Value.Date);
                    dataGridViewEntry.DataSource = listEntry;
                   // dataGridViewRooms.Columns[0].Visible = false;
                    //dataGridViewRooms.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (listExit != null)
                {
                    dataGridViewExit.DataSource = null;
                    listExit.RemoveAll(r => Convert.ToDateTime(r.DepartureDate).Date != dateTimePickerExit.Value.Date);
                    dataGridViewExit.DataSource = listExit;
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

        private async void InitializeExit()
        {
            try
            {
                List<OrderViewModel> listExit = await ApiClient.GetRequestData<List<OrderViewModel>>("api/Order/GetList");
                if (listExit != null)
                {
                    dataGridViewExit.DataSource = null;
                    listExit.RemoveAll(r => Convert.ToDateTime(r.DepartureDate).Date != dateTimePickerExit.Value.Date);
                    dataGridViewExit.DataSource = listExit;
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

        private void dateTimePickerExit_ValueChanged(object sender, EventArgs e)
        {
            InitializeExit();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            if ((dataGridViewExit.SelectedRows[0].Cells[4].Value).ToString() == "Начат")
            {
                if (dataGridViewExit.SelectedRows.Count == 1)
                {
                    var form = new HotelBusinessViewAdmin.Base.PaymentOrder();
                    form.Id = Convert.ToInt32(dataGridViewExit.SelectedRows[0].Cells[0].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        InitializeExit();
                    }
                }
            }
            else MessageBox.Show("Заказ уже оплачен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void buttonCloseOrder_Click(object sender, EventArgs e)
        {
            if ((dataGridViewExit.SelectedRows[0].Cells[4].Value).ToString() == "Оплачен")
            {
                if (dataGridViewExit.SelectedRows.Count == 1)
                {
                    int Id = Convert.ToInt32(dataGridViewExit.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Order/CloseOrder/" + Id);
                        MessageBox.Show("Заказ завершен. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Initialize();
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
            }
            else MessageBox.Show("Заказ не может быть завершен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonDetailEntry_Click(object sender, EventArgs e)
        {
            if (dataGridViewEntry.SelectedRows.Count == 1)
            {
                var form = new HotelBusinessViewAdmin.Base.DetailOrderBase();
                form.Id = Convert.ToInt32(dataGridViewEntry.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        private void buttonDetailExit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExit.SelectedRows.Count == 1)
            {
                var form = new HotelBusinessViewAdmin.Base.DetailOrderBase();
                form.Id = Convert.ToInt32(dataGridViewExit.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void buttonSaveEntryPDF_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

        }
    }
}
