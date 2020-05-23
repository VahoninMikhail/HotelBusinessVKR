using System;
using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class RoomOrderViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public int FormId { get; set; }

        [DataMember]
        public string FormName { get; set; }

        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public string OrderStatus { get; set; }

        [DataMember]
        public int RoomName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public virtual RoomViewModel Room { get; set; }

        [DataMember]
        public virtual OrderViewModel Order { get; set; }
    }
}
