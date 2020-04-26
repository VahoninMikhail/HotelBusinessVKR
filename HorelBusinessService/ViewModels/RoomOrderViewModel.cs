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
        public int RoomName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Total { get; set; }
    }
}
