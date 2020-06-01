using RestApiHotelBusiness.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Admins
{
    public partial class EditAdmin : Form
    {
        public EditAdmin()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string fio = textBoxFIO.Text;
            string login = textBoxLogin.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string message = string.Empty;
            if (string.IsNullOrEmpty(fio))
            {
                message += " Введите ФИО";
            }
            if (!string.IsNullOrEmpty(login))
            {
                if (!Regex.IsMatch(login, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    message += " Неверный формат электронной почты";
                }
            }
            else
            {
                message += " Введите e-mail";
            }
            if (phoneNumber.IndexOf(" ") != -1)
            {
                message += "В номере телефона не должно быть пробелов";
            }
            /*  if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]{5,30}$"))
              {
                  message += " В номере телефона должно быть 11 цифр";
              }*/
            //if (!Regex.IsMatch(password, @"(?=.*[a-z])(?=.*[0-9])^[a-zA-Z0-9]{5,}$"/*@"^(?=.*[0-9]$)(?=.*[a-zA-Z]){5,}"*/))
            // {
            //      message += " Пароль должен быть не менее 5 символов и не более 20 символов, содержать хотя бы одну латинскую букву в нижнем регистре и одну цифру";
            //  }
            if (!password.Equals(confirmPassword))
            {
                message += "Пароли должны совпадать";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task task = Task.Run(() => ApiClient.PostRequestData("api/Account/RegisterAdmin", new RegisterBindingModel
                {
                    UserFIO = fio,
                    Email = login,
                    PhoneNumber = phoneNumber,
                    Password = password,
                    ConfirmPassword = confirmPassword
                }));
                MessageBox.Show("Пользователь зарегистрирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

                /* Task task = Task.Run(() => ApiClient.PostRequestData("api/Account/Register", new RegisterBindingModel
                 {
                     UserFIO = fio,
                     Email = login,
                     PhoneNumber = phoneNumber,
                     Password = password,
                     ConfirmPassword = confirmPassword
                 }));
                 MessageBox.Show("Пользователь зарегистрирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 Close();*/
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
