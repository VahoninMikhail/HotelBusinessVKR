using HorelBusinessService.ViewModels;
using System;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Base
{
    public partial class DetailOrderBase : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public DetailOrderBase()
        {
            InitializeComponent();
        }

        private async void DetailOrderBase_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var form = await ApiClient.GetRequestData<OrderViewModel>("api/Order/Get/" + id.Value);

                    dataGridViewRooms.DataSource = form.RoomOrders;
                    dataGridViewRooms.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridViewRooms.Columns[0].Visible = false;
                    dataGridViewRooms.Columns[1].Visible = false;
                    dataGridViewRooms.Columns[2].Visible = false;
                    dataGridViewRooms.Columns[4].Visible = false;
                    dataGridViewRooms.Columns[5].Visible = false;
                    dataGridViewRooms.Columns[6].Visible = false;
                    dataGridViewRooms.Columns[9].Visible = false;
                    dataGridViewRooms.Columns[10].Visible = false;
                    dataGridViewRooms.Columns[11].Visible = false;

                    dataGridViewServices.DataSource = form.ServiceOrders;
                    dataGridViewServices.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridViewServices.Columns[0].Visible = false;
                    dataGridViewServices.Columns[1].Visible = false;

                    textBoxUser.Text = form.UserFIO;
                    textBoxNumberOrder.Text = form.Id.ToString();
                    textBoxStatus.Text = form.OrderStatus;
                    textBoxFrom.Text = form.ArrivalDate;
                    textBoxBefore.Text = form.DepartureDate;
                    if (form.Payments.Count != 0)
                    {
                        labelPaymentType.Text = "";
                        textBoxDateImplement.Text = form.Payments[0].DateImplement;
                        textBoxSum.Text = form.Payments[0].Summ.ToString();
                        textBoxPayType.Text = form.Payments[0].PayType;
                    }
                    else
                    {
                        labelPaymentType.Text = "Оплата не произведена";
                        groupBoxPayment.Visible = false;
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
        }

        private void labelNumberOrder_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNumberOrder_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
