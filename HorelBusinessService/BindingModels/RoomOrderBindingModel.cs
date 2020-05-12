using System;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class RoomOrderBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }
    }
}
