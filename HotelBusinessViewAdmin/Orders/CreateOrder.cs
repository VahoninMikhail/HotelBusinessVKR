using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                List<UserViewModel> list = Task.Run(() => ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
                if (list != null)
                {
                    comboBoxUsers.DisplayMember = "UserFIO";
                    comboBoxUsers.ValueMember = "Id";
                    comboBoxUsers.DataSource = list;
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
                if (serviceCollection != null)
                {
                    dataGridViewService.DataSource = null;
                    dataGridViewService.DataSource = serviceCollection;
                   // dataGridViewService.Columns[0].Visible = false;
                   // dataGridViewService.Columns[1].Visible = false;
                   // dataGridViewService.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (roomCollection != null)
                {
                    dataGridViewForms.DataSource = null;
                    dataGridViewForms.DataSource = roomCollection;
                //    dataGridViewForms.Columns[0].Visible = false;
                 //   dataGridViewForms.Columns[1].Visible = false;
                //    dataGridViewForms.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                Initialize();
            }
        }

        private void buttonEditForm_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelForm_Click(object sender, EventArgs e)
        {

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
                Initialize();
            }
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelService_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
