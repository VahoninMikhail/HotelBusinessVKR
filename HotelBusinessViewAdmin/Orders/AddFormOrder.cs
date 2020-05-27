using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Orders
{
    public partial class AddFormOrder : System.Windows.Forms.Form
    {
        public List<RoomOrderViewModel> Model = new List<RoomOrderViewModel>();

        public DateTime fromDate { set { dateFrom = value; } }

        private DateTime? dateFrom;

        public DateTime beforeDate { set { dateBefore = value; } }

        private DateTime? dateBefore;


        public AddFormOrder()
        {
            InitializeComponent();
        }

        private void AddFormOrder_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxForms.DisplayMember = "FormName";
                comboBoxForms.ValueMember = "Id";
                comboBoxForms.DataSource = Task.Run(() => ApiClient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                comboBoxForms.SelectedItem = null;
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

        private void buttonAddForm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxForms.SelectedValue == null)
            {
                MessageBox.Show("Выберите комнату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int formId = Convert.ToInt32(comboBoxForms.SelectedValue);
                int quantity = Convert.ToInt32(textBoxCount.Text);
               
                TimeSpan diff1 = dateBefore.Value.AddHours(1).Subtract(dateFrom.Value);
                int days = diff1.Days;

                List<RoomViewModel> listRoom = Task.Run(() => ApiClient.GetRequestData<List<RoomViewModel>>("api/Room/GetList")).Result;
                //
                List<RoomOrderViewModel> listReservation = Task.Run(() => ApiClient.GetRequestData<List<RoomOrderViewModel>>("api/Order/GetListRoomOrder")).Result;

                //
                RoomViewModel room = listRoom.Where(t => t.FormId == formId).FirstOrDefault();

                //удаляем из списка все лишние виды и оставляем только выбранный
                listRoom.RemoveAll(list => list.FormId != formId);

                /* //проверяем выбирали ли мы уже этот вид комнат
                 RoomOrderViewModel line = roomCollection
                     .Where(p => p.Room.FormId == formId)
                     .FirstOrDefault();
                 */

                //Проверка на занятость комнат
                for (int i = 0; i < listReservation.Count; i++)
                {
                    if (listReservation[i].OrderStatus != Convert.ToString(OrderStatus.Завершен))
                    {
                        if (dateFrom.Value >= listReservation[i].ArrivalDate && dateFrom.Value < listReservation[i].DepartureDate)
                        {
                            //если дата входит в диапазон, значит комната занята, удаляем её из списка
                            listRoom.RemoveAll(list => list.Id == listReservation[i].RoomId);
                        }
                        else if (listReservation[i].ArrivalDate >= dateFrom.Value && listReservation[i].ArrivalDate < dateBefore.Value)
                        {
                            //если дата входит в диапазон, значит комната занята, удаляем её из списка
                            listRoom.RemoveAll(list => list.Id == listReservation[i].RoomId);
                        }
                    }
                }

                //проверка хватает ли нам комнат
                if (listRoom.Count < quantity)
                {
                    throw new Exception("Не хватает комнат, осталось " + listRoom.Count + " комнаты данного вида");
                }
                List<FormViewModel> listForm = Task.Run(() => ApiClient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
                //
                /* if (line == null)
                 {*/
                for (int i = 0; i < quantity; i++)
                {
                    Model.Add(new RoomOrderViewModel()
                    {
                        RoomId = listRoom[i].Id,
                        RoomName = listRoom[i].RoomName,
                        Room = listRoom[i],
                        ArrivalDate = dateFrom.Value,
                        DepartureDate = dateBefore.Value,
                        Price = listForm.Where(p => p.Id == listRoom[i].FormId).FirstOrDefault().Price * days,
                        FormName = listRoom[i].FormName,
                        FormId = listRoom[i].FormId
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                /*    }
                    else
                    {
                        //удаляем все комнаты с таким же видом из корзины, если выбрали его еще раз
                        for (int i = 0; i < listRoom.Count; i++)
                        {
                            roomCollection.RemoveAll(list => list.RoomId == listRoom[i].Id);
                        }
                        //
                        for (int i = 0; i < quantity; i++)
                        {
                            roomCollection.Add(new RoomOrderViewModel()
                            {
                                RoomId = listRoom[i].Id,
                                RoomName = listRoom[i].RoomName,
                                Room = listRoom[i],
                                ArrivalDate = dateFrom.Value,
                                DepartureDate = dateBefore.Value,
                                Price = listForm.Where(p => p.Id == listRoom[i].FormId).FirstOrDefault().Price * days
                            });
                        }
                    }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
