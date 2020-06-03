using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Base
{
    public partial class PaymentOrder : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public PaymentOrder()
        {
            InitializeComponent();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            if (checkBoxCash.Checked == false && checkBoxCard.Checked == false)
            {
                MessageBox.Show("Выберите способ оплаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string paytype = "";
            if (checkBoxCash.Checked == true) paytype = "Наличные";
            else if (checkBoxCard.Checked == true) paytype = "Безналичные";
            decimal payed = Convert.ToDecimal(textBoxSum.Text);
            Task task = Task.Run(() => ApiClient.PostRequestData("api/Order/CreatePayment", new PaymentBindingModel
            {
               OrderId = id.Value,
               Summ = payed,
               PayType = paytype
            }));
            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, TaskContinuationOptions.OnlyOnFaulted);
            Close();
        }

        private async void PaymentOrder_Load(object sender, EventArgs e)
        {
            var form = await ApiClient.GetRequestData<OrderViewModel>("api/Order/Get/" + id.Value);
            textBoxSum.Text = form.Sum.ToString();
        }
    }
}
