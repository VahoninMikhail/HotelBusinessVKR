using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Reviews
{
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private void Reviews_Load(object sender, EventArgs e)
        {
            Initialize();
            if (dataGridViewReviews.SelectedRows.Count == 1)
            {
                string text = Convert.ToString(dataGridViewReviews.SelectedRows[0].Cells[3].Value);

                richTextBoxReview.Text = text;
            }
        }

        private async void Initialize()
        {
            try
            {
                List<ReviewViewModel> listReviews = await ApiClient.GetRequestData<List<ReviewViewModel>>("api/Order/GetListReview");
                if (listReviews != null)
                {
                    dataGridViewReviews.DataSource = listReviews;
                    dataGridViewReviews.Columns[0].HeaderText = "Номер заказа";
                    dataGridViewReviews.Columns[1].HeaderText = "ФИО клиента";
                    dataGridViewReviews.Columns[2].HeaderText = "Почта клиента";
                    dataGridViewReviews.Columns[3].Visible = false;

                    dataGridViewReviews.Columns[0].Width = 50;
                    dataGridViewReviews.Columns[1].Width = 150;
                    dataGridViewReviews.Columns[2].Width = 150;
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

        private void dataGridViewReviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = Convert.ToString(dataGridViewReviews.SelectedRows[0].Cells[3].Value);

            richTextBoxReview.Text = text;
        }

        private async void buttonSendReplyReview_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отправить ответ пользователю?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idOrder = Convert.ToInt32(dataGridViewReviews.SelectedRows[0].Cells[0].Value);
                string mail = Convert.ToString(dataGridViewReviews.SelectedRows[0].Cells[2].Value);
                string text = richTextBoxReplyReview.Text;

                try
                {
                    await ApiClient.PostRequestData("api/Report/SendReplyReview", new ReviewBindingModel
                    {
                        OrderId = idOrder,
                        UserMail = mail,
                        Text = text
                    });
                    MessageBox.Show("Ответ отправлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
