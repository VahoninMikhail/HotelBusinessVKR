using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class OrderPogashenieViewModel
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public List<ServiceOrderViewModel> Services { get; set; }

        [DataMember]
        public List<RoomOrderViewModel> Rooms { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public decimal TotalPaid { get; set; }

        [DataMember]
        public decimal Pogashenie { get; set; }
    }
}