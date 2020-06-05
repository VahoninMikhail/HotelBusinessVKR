using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Rooms
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                List<RoomViewModel> list = await ApiClient.GetRequestData<List<RoomViewModel>>("api/Room/GetList");
                if (list != null)
                {
                    dataGridViewRooms.DataSource = list;
                    dataGridViewRooms.Columns[0].Visible = false;
                    dataGridViewRooms.Columns[1].HeaderText = "Номер комнаты";
                    dataGridViewRooms.Columns[2].Visible = false;
                    dataGridViewRooms.Columns[3].HeaderText = "Вид номера";
                    dataGridViewRooms.Columns[4].Visible = false;

                    dataGridViewRooms.Columns[1].Width = 100;
                    dataGridViewRooms.Columns[3].Width = 150;
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
            var form = new EditRoom();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 1)
            {
                var form = new EditRoom();
                form.Id = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Initialize();
                }
            }
        }

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Room/DelElement/" + id);
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
