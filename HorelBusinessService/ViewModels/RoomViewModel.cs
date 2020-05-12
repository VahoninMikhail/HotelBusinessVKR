using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class RoomViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoomName { get; set; }

        [DataMember]
        public int FormId { get; set; }

        [DataMember]
        public string FormName { get; set; }

        [DataMember]
        public string Active { get; set; }
    }
}