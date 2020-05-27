using HorelBusinessService.App;
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

        private void Initialize()
        {
            try
            {
                //var r = Task.Run(() => ApiClient.GetRequestData<IEnumerable<AppRole>>("api/Account/GetRole")).Result;
                // List<UserViewModel> listUser = await ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetListUser");
                List<UserViewModel> list = Task.Run(() => ApiClient.GetRequestData<List<UserViewModel>>("api/Account/GetList")).Result;
                if (list != null)
                {
                    dataGridViewUsers.DataSource = list;
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

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

        }
    }
}
