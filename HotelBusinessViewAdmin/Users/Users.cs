using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Users
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                List<UserViewModel> listUser = await ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetListUser");
               // List<UserViewModel> list = Task.Run(() => ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
                if (listUser != null)
                {
                    dataGridViewUsers.DataSource = listUser;
                    dataGridViewUsers.Columns[0].Visible = false;
                    dataGridViewUsers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            var form = new EditUser();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = Convert.ToString(dataGridViewUsers.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Account/DelElement/" + id);
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

        private async void buttonBlock_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Заблокировать пользователя", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = Convert.ToString(dataGridViewUsers.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Account/BlockElement/" + id);
                        MessageBox.Show("Пользователь заблокирован. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void buttonUnblock_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Разблокировать пользователя", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = Convert.ToString(dataGridViewUsers.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Account/UnblockElement/" + id);
                        MessageBox.Show("Пользователь разблокирован. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                var form = new HotelBusinessViewAdmin.Base.DetailOrderBase();
                form.Id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private async void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = Convert.ToString(dataGridViewUsers.SelectedRows[0].Cells[0].Value);
            var form = await ApiClient.GetRequestData<List<OrderViewModel>>("api/Order/GetPosetitelList/" + id);
           // var form = await ApiClient.GetRequestData<List<OrderViewModel>>("api/Order/GetList");
           // form.RemoveAll(r => r.UserId != id);

            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = form;
        }
    }
}
