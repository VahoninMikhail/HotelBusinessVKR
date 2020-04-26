using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class FormFreeServiceViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Total { get; set; }
    }
}
