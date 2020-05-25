using HorelBusinessService;
using System;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Autorization
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        private void sign_In_Click(object sender, EventArgs e)
        {
            try
            {
                ApiClient.Login(textBoxLogin.Text, textBoxPassword.Text);

                if (ApiClient.Role.Equals(ApplicationRoles.Admin))
                {
                    FormBase formBaseAdmin = new FormBase(this);
                    formBaseAdmin.Show();
                    Hide();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Произошла ошибка авторизации\nОшибка:", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                }
                textBoxLogin.Clear();
                textBoxPassword.Clear();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Произошла ошибка авторизации\nОшибка:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
            }
        }

        private void sign_Up_Click(object sender, EventArgs e)
        {

        }
    }
}
