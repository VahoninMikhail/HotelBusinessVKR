using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Forms
{
    public partial class AddFreeService : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public AddFreeService()
        {
            InitializeComponent();
        }

        private void AddFreeService_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            if (id.HasValue)
            {
                try
                {
                    comboBoxService.DisplayMember = "ServiceName";
                    comboBoxService.ValueMember = "Id";
                    comboBoxService.DataSource = await ApiClient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList");
                    comboBoxService.SelectedItem = null;

                    //comboBoxService.SelectedValue = id.Value;
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
            else
            {

            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxService.Text))
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int serviceId = Convert.ToInt32(comboBoxService.SelectedValue);
                if (id.HasValue)
                {
                    await ApiClient.PostRequestData("api/Form/AddFreeServiceElement", new FormFreeServiceBindingModel
                    {
                        ServiceId = serviceId,
                        FormId = id.Value
                    });
                }
                else
                {
                    
                }
                MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
