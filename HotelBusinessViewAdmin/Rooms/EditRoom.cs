using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Rooms
{
    public partial class EditRoom : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public EditRoom()
        {
            InitializeComponent();
        }

        private void EditRoom_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            if (id.HasValue)
            {
                try
                {
                    var room = await ApiClient.GetRequestData<RoomViewModel>("api/Room/Get/" + id.Value);
                    textBoxName.Text = Convert.ToString(room.RoomName);

                    comboBoxForm.DisplayMember = "FormName";
                    comboBoxForm.ValueMember = "Id";
                    comboBoxForm.DataSource = Task.Run(() => ApiClient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                    comboBoxForm.SelectedItem = null;

                    comboBoxForm.SelectedValue = id.Value;
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
                try
                {
                    comboBoxForm.DisplayMember = "FormName";
                    comboBoxForm.ValueMember = "Id";
                    comboBoxForm.DataSource = Task.Run(() => ApiClient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                    comboBoxForm.SelectedItem = null;
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
            if (string.IsNullOrEmpty(comboBoxForm.Text))
            {
                MessageBox.Show("Выберите вид номера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int name = Convert.ToInt32(textBoxName.Text);
                int formId = Convert.ToInt32(comboBoxForm.SelectedValue);
                if (id.HasValue)
                {
                    await ApiClient.PostRequestData("api/Room/UpdElement", new RoomBindingModel
                    {
                        Id = id.Value,
                        RoomName = name,
                        FormId = formId
                    });
                }
                else
                {
                    await ApiClient.PostRequestData("api/Room/AddElement", new RoomBindingModel
                    {
                        RoomName = name,
                        FormId = formId
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
