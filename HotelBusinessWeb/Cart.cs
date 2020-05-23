using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBusinessWeb
{
    public class Cart
    {
        private List<ServiceOrderViewModel> lineCollection = new List<ServiceOrderViewModel>();
        private List<RoomOrderViewModel> roomCollection = new List<RoomOrderViewModel>();

        public void AddRoomItem(int formId, int quantity, DateTime fromDate, DateTime beforeDate)
        {
            TimeSpan diff1 = beforeDate.Subtract(fromDate);
            int days = diff1.Days;

            List<RoomViewModel> listRoom = Task.Run(() => APIСlient.GetRequestData<List<RoomViewModel>>("api/Room/GetList")).Result;
            //
            List<RoomOrderViewModel> listReservation = Task.Run(() => APIСlient.GetRequestData<List<RoomOrderViewModel>>("api/Order/GetListRoomOrder")).Result;
            
            //
            RoomViewModel room = listRoom.Where(t => t.FormId == formId).FirstOrDefault();

            //проверяем выбирали ли мы уже этот вид комнат
            RoomOrderViewModel line = roomCollection
                .Where(p => p.Room.FormId == formId)
                .FirstOrDefault();
            //удаляем из списка все лишние виды и оставляем только выбранный
            listRoom.RemoveAll(list => list.FormId != formId);
            //Проверка на занятость комнат
            for (int i = 0; i < listReservation.Count; i++)
            {
                if (listReservation[i].OrderStatus != Convert.ToString(OrderStatus.Завершен))
                {
                        if (fromDate >= listReservation[i].ArrivalDate && fromDate < listReservation[i].DepartureDate)
                        {
                            //если дата входит в диапазон, значит комната занята, удаляем её из списка
                            listRoom.RemoveAll(list => list.Id == listReservation[i].RoomId);
                        }
                        else if (listReservation[i].ArrivalDate >= fromDate && listReservation[i].ArrivalDate < beforeDate)
                        {
                            //если дата входит в диапазон, значит комната занята, удаляем её из списка
                            listRoom.RemoveAll(list => list.Id == listReservation[i].RoomId);
                        }
                }
            }
            //проверка хватает ли нам комнат
            if (listRoom.Count< quantity)
            {
                throw new Exception("Не хватает комнат, осталось " + listRoom.Count + " комнаты данного вида");
            }
            List<FormViewModel> listForm= Task.Run(() => APIСlient.GetRequestData<List<FormViewModel>>("api/Form/GetList")).Result;
            //
            if (line == null)
            {
                for (int i = 0; i < quantity; i++)
                {
                    roomCollection.Add(new RoomOrderViewModel()
                    {
                        RoomId = listRoom[i].Id,
                        RoomName = listRoom[i].RoomName,
                        Room = listRoom[i],
                        ArrivalDate = fromDate,
                        DepartureDate = beforeDate,
                        Price = listForm.Where(p => p.Id == listRoom[i].FormId).FirstOrDefault().Price*days
                });
                }
            }
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
                        ArrivalDate = fromDate,
                        DepartureDate = beforeDate,
                        Price = listForm.Where(p => p.Id == listRoom[i].FormId).FirstOrDefault().Price * days
                    });
                }
            }
        }

        public IEnumerable<RoomOrderViewModel> LinesRoom
        {
            get { return roomCollection; }
        }

        public void RemoveRoomLine(int roomId)
        {
            roomCollection.RemoveAll(l => l.RoomId == roomId);
        }

        public void AddItem(int serviceId, int quantity)
        {
            ServiceOrderViewModel line = lineCollection
                .Where(p => p.ServiceId == serviceId)
                .FirstOrDefault();

            ServiceViewModel service = Task.Run(() => APIСlient.GetRequestData<ServiceViewModel>("api/Service/Get/" + serviceId)).Result;

            if (line == null)
            {
                lineCollection.Add(new ServiceOrderViewModel
                {
                    ServiceId = service.Id,
                    ServiceName = service.ServiceName,
                    Count = quantity,
                    Price = service.Price,
                    Total = service.Price * quantity
                });
            }
            else
            {
                line.Count += quantity;
                line.Total = line.Price * line.Count;
            }
        }

        public void RemoveLine(int serviceId)
        {
            lineCollection.RemoveAll(l => l.ServiceId == serviceId);
        }

        public void RemoveAll()
        {
            lineCollection.RemoveAll(l => l.ServiceId >= 0);
            roomCollection.RemoveAll(l => l.RoomId >= 0);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Total) + roomCollection.Sum(e => e.Price);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<ServiceOrderViewModel> Lines
        {
            get { return lineCollection; }
        }
    }
}