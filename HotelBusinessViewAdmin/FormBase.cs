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
                if (listEntry != null)
                {
                    dataGridViewEntry.DataSource = null;
                    listEntry.RemoveAll(r => Convert.ToDateTime(r.ArrivalDate).Date != dateTimePickerEntry.Value.Date);
                    dataGridViewEntry.DataSource = listEntry;
                    dataGridViewEntry.Columns[0].HeaderText = "Номер заказа";
                    dataGridViewEntry.Columns[1].Visible = false;
                    dataGridViewEntry.Columns[2].HeaderText = "ФИО клиента";
                    dataGridViewEntry.Columns[3].HeaderText = "Почта клиента";
                    dataGridViewEntry.Columns[4].HeaderText = "Статус заказа";
                    dataGridViewEntry.Columns[5].HeaderText = "Дата въезда";
                    dataGridViewEntry.Columns[6].HeaderText = "Дата выезда";
                    dataGridViewEntry.Columns[7].Visible = false;
                    dataGridViewEntry.Columns[8].Visible = false;
                    dataGridViewEntry.Columns[9].Visible = false;
                    dataGridViewEntry.Columns[10].Visible = false;

                    dataGridViewEntry.Columns[0].Width = 60;
                    dataGridViewEntry.Columns[2].Width = 110;
                    dataGridViewEntry.Columns[3].Width = 110;
                    dataGridViewEntry.Columns[4].Width = 70;
                    dataGridViewEntry.Columns[5].Width = 100;
                    dataGridViewEntry.Columns[6].Width = 100;
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
                    dataGridViewExit.Columns[0].HeaderText = "Номер заказа";
                    dataGridViewExit.Columns[1].Visible = false;
                    dataGridViewExit.Columns[2].HeaderText = "ФИО клиента";
                    dataGridViewExit.Columns[3].HeaderText = "Почта клиента";
                    dataGridViewExit.Columns[4].HeaderText = "Статус заказа";
                    dataGridViewExit.Columns[5].HeaderText = "Дата въезда";
                    dataGridViewExit.Columns[6].HeaderText = "Дата выезда";
                    dataGridViewExit.Columns[7].Visible = false;
                    dataGridViewExit.Columns[8].Visible = false;
                    dataGridViewExit.Columns[9].Visible = false;
                    dataGridViewExit.Columns[10].Visible = false;

                    dataGridViewExit.Columns[0].Width = 60;
                    dataGridViewExit.Columns[2].Width = 110;
                    dataGridViewExit.Columns[3].Width = 110;
                    dataGridViewExit.Columns[4].Width = 70;
                    dataGridViewExit.Columns[5].Width = 100;
                    dataGridViewExit.Columns[6].Width = 100;
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
            if (dataGridViewExit.SelectedRows.Count == 1)
            {
                if ((dataGridViewExit.SelectedRows[0].Cells[4].Value).ToString() == "Начат")
                {              
                    var form = new HotelBusinessViewAdmin.Base.PaymentOrder();
                    form.Id = Convert.ToInt32(dataGridViewExit.SelectedRows[0].Cells[0].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        InitializeExit();
                    }
                }
                else MessageBox.Show("Заказ уже оплачен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не выбран заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void buttonCloseOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewExit.SelectedRows.Count == 1)
            {
                if ((dataGridViewExit.SelectedRows[0].Cells[4].Value).ToString() == "Оплачен")
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
                else MessageBox.Show("Заказ не может быть завершен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не выбран заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else MessageBox.Show("Не выбран заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else MessageBox.Show("Не выбран заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonSaveEntryPDF_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            var form2 = new HotelBusinessViewAdmin.Reports.FormReportRooms();
            if (form2.ShowDialog() == DialogResult.OK)
            {

            }
            var form = new HotelBusinessViewAdmin.Reports.FormReportPayments();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
            var form1 = new HotelBusinessViewAdmin.Reports.FormReportTotal();
            if (form1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonReviews_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Reviews.Reviews();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void созданиеЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Orders.CreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void отзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Reviews.Reviews();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void управлениеВидамиНомеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Forms.Forms();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void управлениеНомерамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Rooms.Rooms();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void управлениеУслугамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Services.Services();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Users.Users();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void администраторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Admins.Admins();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void отчётОВыручкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Reports.FormReportTotal();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void отчётОЗанятыхКомнатахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Reports.FormReportRooms();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void отчётОбОплатахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Reports.FormReportPayments();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}