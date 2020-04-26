using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string OrderStatus { get; set; }

        [DataMember]
        public string ArrivalDate { get; set; }

        [DataMember]
        public string DepartureDate { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public decimal Paid { get; set; }

        [DataMember]
        public decimal Pogashenie { get; set; }

        [DataMember]
        public List<ServiceOrderViewModel> ServiceOrders { get; set; }

        [DataMember]
        public List<RoomOrderViewModel> RoomOrders { get; set; }

        [DataMember]
        public DateTime PogashenieDate { get; set; }
    }
}