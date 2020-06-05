using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Orders
{
    public partial class CreateOrder : Form
    {
        private List<ServiceOrderViewModel> serviceCollection;
        private List<RoomOrderViewModel> roomCollection;

        private List<FormViewModel> formCollection;

        public CreateOrder()
        {
            InitializeComponent();
        }

        private void CreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<UserViewModel> list = Task.Run(() => ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetListUser")).Result;
                if (list != null)
                {
                    comboBoxUsers.DisplayMember = "UserFIO";
                    comboBoxUsers.ValueMember = "Id";
                    comboBoxUsers.DataSource = list;
                    comboBoxUsers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUsers.AutoCompleteSource = AutoCompleteSource.ListItems;
                    comboBoxUsers.SelectedItem = null;
                }
                dateTimePickerFrom.Value = DateTime.Now;
                dateTimePickerBefore.Value = DateTime.Now.AddDays(1);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            serviceCollection = new List<ServiceOrderViewModel>();
            roomCollection = new List<RoomOrderViewModel>();
            formCollection = new List<FormViewModel>();
        }

        private void Initialize()
        {
            try
            {
                dataGridViewFreeService.DataSource = null;

                
                if (serviceCollection != null)
                {
                    BindingSource binding = new BindingSource();
                    binding.SuspendBinding();
                    binding.DataSource = serviceCollection;
                    binding.ResumeBinding();

                    dataGridViewService.DataSource = null;
                    dataGridViewService.DataSource = binding;

                    dataGridViewService.Columns[0].Visible = false;
                    dataGridViewService.Columns[1].Visible = false;
                    dataGridViewService.Columns[2].HeaderText = "Название услуги";
                    dataGridViewService.Columns[3].HeaderText = "Кол-во";
                    dataGridViewService.Columns[4].HeaderText = "Цена";
                    dataGridViewService.Columns[5].HeaderText = "Общая стоимость";
                    dataGridViewService.Columns[2].Width = 150;
                    dataGridViewService.Columns[3].Width = 50;
                    dataGridViewService.Columns[4].Width = 60;
                    dataGridViewService.Columns[5].Width = 70;
                }
                if (roomCollection != null)
                {
                    BindingSource binding = new BindingSource();
                    binding.SuspendBinding();
                    binding.DataSource = roomCollection;
                    binding.ResumeBinding();

                    dataGridViewForms.DataSource = null;
                    dataGridViewForms.DataSource = binding;

                    dataGridViewForms.Columns[0].Visible = false;
                    dataGridViewForms.Columns[1].Visible = false;
                    dataGridViewForms.Columns[2].Visible = false;
                    dataGridViewForms.Columns[3].HeaderText = "Вид комнаты";
                    dataGridViewForms.Columns[4].Visible = false;
                    dataGridViewForms.Columns[5].Visible = false;
                    dataGridViewForms.Columns[6].Visible = false;
                    dataGridViewForms.Columns[7].HeaderText = "Номер комнаты";
                    dataGridViewForms.Columns[8].HeaderText = "Стоимость";
                    dataGridViewForms.Columns[9].Visible = false;
                    dataGridViewForms.Columns[10].Visible = false;
                    dataGridViewForms.Columns[11].Visible = false;

                    dataGridViewForms.Columns[3].Width = 100;
                    dataGridViewForms.Columns[7].Width = 60;
                    dataGridViewForms.Columns[8].Width = 70;

                    groupBoxServices.Enabled = true;
                    groupBoxPayment.Enabled = true;
                }
                else
                {
                    dataGridViewService.Enabled = false;
                    groupBoxPayment.Enabled = false;
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddForm_Click(object sender, EventArgs e)
        {
            var form = new AddFormOrder();
            form.fromDate = dateTimePickerFrom.Value;
            form.beforeDate = dateTimePickerBefore.Value;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    //проверяем выбирали ли мы уже этот вид комнат
                    RoomOrderViewModel line = roomCollection
                     .Where(p => p.Room.FormId == form.Model[0].FormId)
                     .FirstOrDefault();

                    //удаляем все комнаты с таким же видом из корзины, если выбрали его еще раз
                    if (line != null)
                    {
                        for (int i = 0; i < roomCollection.Count; i++)
                        {
                            roomCollection.RemoveAll(list => list.RoomId == form.Model[i].RoomId);
                        }
                    }
                    //добавляем комнаты в список
                    for (int i = 0; i < form.Model.Count; i++)
                    {                        
                        roomCollection.Add(form.Model[i]);
                    }
                    //Добавляем их в список для пользователя
                }
                textBoxSumRoom.Text = roomCollection.Select(rec => rec.Price).DefaultIfEmpty(0).Sum().ToString();
                textBoxSum.Text = (roomCollection.Select(rec => rec.Price).DefaultIfEmpty(0).Sum() + serviceCollection.Select(rec => rec.Total).DefaultIfEmpty(0).Sum()).ToString();
                Initialize();
            }
        }

        private void buttonDelForm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[2].Value);

            roomCollection.RemoveAll(r => r.FormId == id);
            Initialize();
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            var form = new AddServiceOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    serviceCollection.Add(form.Model);
                }
                textBoxSumService.Text = serviceCollection.Select(rec => rec.Total).DefaultIfEmpty(0).Sum().ToString();
                textBoxSum.Text = (roomCollection.Select(rec => rec.Price).DefaultIfEmpty(0).Sum() + serviceCollection.Select(rec => rec.Total).DefaultIfEmpty(0).Sum()).ToString();
                Initialize();
            }
        }

        private void buttonDelService_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewService.SelectedRows[0].Cells[1].Value);

            serviceCollection.RemoveAll(r => r.ServiceId == id);
            Initialize();
        }

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue == null)
            {
                MessageBox.Show("Выберите посетителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (roomCollection == null || roomCollection.Count == 0)
            {
                MessageBox.Show("Выберите номер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (serviceCollection == null || serviceCollection.Count == 0)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerFrom.Value < DateTime.Now.Date)
            {
                MessageBox.Show("Дата не может быть меньше настоящей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerBefore.Value < DateTime.Now.Date || dateTimePickerBefore.Value < dateTimePickerFrom.Value)
            {
                MessageBox.Show("Дата не может быть меньше настоящей и меньше даты заезда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Нет суммы оплаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkBoxCash.Checked == false && checkBoxCard.Checked == false)
            {
                MessageBox.Show("Выберите способ оплаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<ServiceOrderBindingModel> serviceBM = new List<ServiceOrderBindingModel>();
            foreach (var i in serviceCollection)
            {
                serviceBM.Add(new ServiceOrderBindingModel
                {
                    ServiceId = i.ServiceId,
                    Count = i.Count
                });
            }

            DateTime arrivalDate = DateTime.Today;
            DateTime departureDate = DateTime.Today;
            List<RoomOrderBindingModel> roomBM = new List<RoomOrderBindingModel>();
            foreach (var i in roomCollection)
            {
                arrivalDate = i.ArrivalDate;
                departureDate = i.DepartureDate;

                roomBM.Add(new RoomOrderBindingModel
                {
                    ArrivalDate = i.ArrivalDate,
                    DepartureDate = i.DepartureDate,
                    RoomId = i.RoomId
                });
            }

            string userId = Convert.ToString(comboBoxUsers.SelectedValue);
            decimal payed = Convert.ToDecimal(textBoxSum.Text);
            string paytype = "";
            if (checkBoxCash.Checked == true) paytype = "Наличные";
            else if (checkBoxCard.Checked == true) paytype = "Безналичные";
            Task task = Task.Run(() => ApiClient.PostRequestData("api/Order/AddElement", new OrderBindingModel
            {
                UserId = userId,
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                RoomOrders = roomBM,
                ServiceOrders = serviceBM,
                Payed = payed,
                PayType = paytype
            }));          
            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, TaskContinuationOptions.OnlyOnFaulted);

            Close();
        }

        private async void dataGridViewForms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[2].Value);
            var form = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + id);

            dataGridViewFreeService.DataSource = null;
            dataGridViewFreeService.DataSource = form.FormFreeServices;
            dataGridViewFreeService.Columns[0].Visible = false;
            dataGridViewFreeService.Columns[1].Visible = false;
            dataGridViewFreeService.Columns[2].HeaderText = "Бесплатные услуги";
            dataGridViewFreeService.Columns[3].Visible = false;
            dataGridViewFreeService.Columns[4].Visible = false;

            dataGridViewFreeService.Columns[2].Width = 200;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            groupBoxUserPeriod.Enabled = true;

            groupBoxForms.Enabled = false;
            
            serviceCollection.Clear();
            roomCollection.Clear();
            Initialize();

            groupBoxServices.Enabled = false;

            groupBoxPayment.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            groupBoxUserPeriod.Enabled = false;

            groupBoxForms.Enabled = true;
        }
    }
}
