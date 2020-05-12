using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class RoomBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoomName { get; set; }

        [DataMember]
        public int FormId { get; set; }
    }
}