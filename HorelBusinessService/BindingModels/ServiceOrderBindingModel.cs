using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class ServiceOrderBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
