using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Orders
{
    public partial class AddServiceOrder : Form
    {
        public ServiceOrderViewModel Model { get; set; }

        public AddServiceOrder()
        {
            InitializeComponent();
        }

        private void AddServiceOrder_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxService.DisplayMember = "ServiceName";
                comboBoxService.ValueMember = "Id";
                comboBoxService.DataSource = Task.Run(() => ApiClient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList")).Result;
                comboBoxService.SelectedItem = null;
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

        private async void buttonAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxService.SelectedValue == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (Model == null)
                {
                    Model = new ServiceOrderViewModel
                    {
                        ServiceId = Convert.ToInt32(comboBoxService.SelectedValue),
                        ServiceName = comboBoxService.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    Model.Count = Convert.ToInt32(textBoxCount.Text);
                }
                var model = await Task.Run(() => ApiClient.GetRequestData<ServiceViewModel>("api/Service/Get/" + Model.ServiceId));
                Model.Price = model.Price;
                Model.Total = Model.Price * Model.Count;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
