using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Admins
{
    public partial class Admins : Form
    {
        public Admins()
        {
            InitializeComponent();
        }

        private void Admins_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                List<UserViewModel> listUser = await ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetListAdmin");
                // List<UserViewModel> list = Task.Run(() => ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
                if (listUser != null)
                {
                    dataGridViewAdmins.DataSource = listUser;
                    dataGridViewAdmins.Columns[0].Visible = false;
                    dataGridViewAdmins.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            var form = new EditAdmin();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
