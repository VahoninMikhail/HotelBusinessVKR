using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class ServiceViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string ServiceSpecification { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}
