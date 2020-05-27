using HotelBusinessViewAdmin.Autorization;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin
{
    public partial class FormBase : Form
    {
        private FormAuthorization parent;

        public FormBase(FormAuthorization parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelUserName.Text += ApiClient.UserName;
        }

        private void buttonForm_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Forms.Forms();
            if (form.ShowDialog() == DialogResult.OK)
            {
               
            }
        }

        private void buttonServices_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Services.Services();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonRooms_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Rooms.Rooms();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonUsers_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Users.Users();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonCreateOrder_Click(object sender, System.EventArgs e)
        {
            var form = new HotelBusinessViewAdmin.Orders.CreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
