using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Services
{
    public partial class EditService : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public EditService()
        {
            InitializeComponent();
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            if (id.HasValue)
            {
                try
                {
                    var service = await ApiClient.GetRequestData<ServiceViewModel>("api/Service/Get/" + id.Value);
                    textBoxName.Text = service.ServiceName;
                    textBoxSpecification.Text = service.ServiceSpecification;
                    textBoxPrice.Text = Convert.ToString(service.Price);
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

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните Наименование", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните Стоимость", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSpecification.Text))
            {
                MessageBox.Show("Заполните Описание", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string name = textBoxName.Text;
                decimal price = Convert.ToDecimal(textBoxPrice.Text);
                string specification = textBoxSpecification.Text;
                if (id.HasValue)
                {
                        await ApiClient.PostRequestData("api/Service/UpdElement", new ServiceBindingModel
                        {
                            Id = id.Value,
                            ServiceName = name,
                            Price = price,
                            ServiceSpecification = specification
                        });
                }
                else
                {
                        await ApiClient.PostRequestData("api/Service/AddElement", new ServiceBindingModel
                        {
                            ServiceName = name,
                            Price = price,
                            ServiceSpecification = specification
                        });
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
