using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Services
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                List<ServiceViewModel> list = await ApiClient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList");
                if (list != null)
                {
                    dataGridViewService.DataSource = list;
                    dataGridViewService.Columns[0].Visible = false;
                    dataGridViewService.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new EditService();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewService.SelectedRows.Count == 1)
            {
                var form = new EditService();
                form.Id = Convert.ToInt32(dataGridViewService.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Initialize();
                }
            }
        }

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewService.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewService.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Service/DelElement/" + id);
                        MessageBox.Show("Запись удалена. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
