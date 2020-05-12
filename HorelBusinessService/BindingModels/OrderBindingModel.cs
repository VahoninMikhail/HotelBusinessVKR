using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public int Payed { get; set; }

        [DataMember]
        public List<ServiceOrderBindingModel> ServiceOrders { get; set; }

        [DataMember]
        public List<RoomOrderBindingModel> RoomOrders { get; set; }
    }
}
