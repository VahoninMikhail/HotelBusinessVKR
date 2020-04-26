using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class ServiceBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string ServiceSpecification { get; set; }
    }
}
